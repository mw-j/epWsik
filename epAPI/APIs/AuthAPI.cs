using epAPI.DTOs;
using epAPI.Helpers;
using System.Data.SqlClient;

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
            try
            {
                UserModel? user = await data.GetUserByEmail(dto.Email);
                if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                {
                    return Results.BadRequest("Invalid Credentials");
                }

                var jwt = _jwtService.Generate(user.UserId);

                http.Response.Cookies.Append("jwt", jwt, new CookieOptions { HttpOnly = true});
                
                return Results.Ok(user);
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
                if (jwt != null) {
                    var token = _jwtService.Verify(jwt);
                    Guid userId = Guid.Parse(token.Issuer);

                    var results = await data.GetUser(userId);
                    if (results == null) return Results.NotFound();
                    return Results.Ok(results);

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
