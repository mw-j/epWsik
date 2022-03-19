namespace epAPI.DTOs
{
    [TsInterface]
    public class UserLoginDTO
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
