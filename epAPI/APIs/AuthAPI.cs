using epAPI.DTOs;
using epAPI.Helpers;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace epAPI.APIs
{
    internal static class AuthAPI
    {
        private static readonly JwtService _jwtService;
        static AuthAPI() { 
            _jwtService = new JwtService();
        }

        internal static async Task<IResult> RegisterUser(UserRegisterDTO dto, IUserData data)
        {
            try
            {
                UserModel user = new UserModel
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Email = dto.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
                };
                await data.InsertUser(user);
                return Results.Ok();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    return Results.BadRequest("E-Mail-Adresse existiert bereits");
                }
                else {
                    return Results.Problem(ex.Message);
                }
            }
            catch (Exception ex)
            {
                   return Results.Problem(ex.Message);
            }
        }

        internal static async Task<IResult> LoginUser(UserLoginDTO dto, HttpContext http, IUserData data)
        {
            UserLoginResponseDTO userLoginResponseDTO = new UserLoginResponseDTO();
            try
            {
                UserModel? user = await data.GetUserByEmail(dto.Email);
                if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                {
                    return Results.BadRequest("Invalid Credentials");
                }

                string jwt = await _jwtService.Generate(user.UserId, data);
                userLoginResponseDTO.jwtToken = jwt;
                userLoginResponseDTO.userDTO = new UserDTO
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                http.Response.Cookies.Append("jwt", jwt, new CookieOptions { HttpOnly = true});
                
                return Results.Ok(userLoginResponseDTO);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        internal static IResult LogoutUser(HttpContext http) {
            http.Response.Cookies.Delete("jwt");
            return Results.Ok();
        }

        internal static async Task<IResult> User(HttpContext http, IUserData data)
        {
            try
            {
                string? jwt = http.Request.Cookies["jwt"];
                if (jwt == null) {
                    string jwt_bearer = http.Request.Headers.Authorization.Where(s => s.StartsWith("Bearer")).FirstOrDefault("");
                    if (jwt_bearer != "Bearer null") {
                        jwt = jwt_bearer[7..];
                    }
                    else {
                        return Results.Unauthorized();
                    }    
                };
                if (jwt != null) {
                    var token = _jwtService.Verify(jwt);
                    Guid userId = Guid.Parse(token.Claims.Where(c => c.Type == JwtRegisteredClaimNames.NameId).Select(c => c.Value).SingleOrDefault(""));

                    var results = await data.GetUser(userId);
                    if (results == null) return Results.NotFound();
                    UserDTO userDTO = new UserDTO
                    {
                        UserId = results.UserId,
                        Email = results.Email,
                        FirstName = results.FirstName,
                        LastName = results.LastName,

                    };
                    return Results.Ok(userDTO);

                }

                return Results.Unauthorized();
                
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
