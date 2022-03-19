using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace epAPI.Helpers
{
    public class JwtService
    {
        private string secureKey = "ajd0932nn§$%!g5305)?§adm08vb<klpowe";
        public async Task<string> Generate(Guid userId, IUserData data) 
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secureKey));
            SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtHeader header = new JwtHeader(credentials);

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.NameId, userId.ToString()),
            };

            UserModel? user = await data.GetUser(userId);
            if (user != null) {
                claims.Add(new Claim(ClaimTypes.Name, user.FirstName)); // match ASP.net User.Identity.Name
                //claims.Append(new Claim(ClaimTypes.Role, )); // match ASP.net [Authorize(Roles="Administrator")]
                claims.Add(new Claim(JwtRegisteredClaimNames.Name, user.FirstName)); // match JWT RFC
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            };

            //JwtPayload payload = new JwtPayload(userId.ToString(), null, null, null, DateTime.Today.AddDays(1));
            //JwtSecurityToken securityToken = new JwtSecurityToken(header, payload);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: "epAPI",
                audience: "epVueFrontend",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);       
        }

        public JwtSecurityToken Verify(string jwt)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secureKey);
            tokenHandler.ValidateToken(jwt, 
                new TokenValidationParameters { 
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidIssuer = "epAPI",
                    ValidateAudience = true,
                    ValidAudience = "epVueFrontend"

                }, 
                out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;

        }
    }    
}
