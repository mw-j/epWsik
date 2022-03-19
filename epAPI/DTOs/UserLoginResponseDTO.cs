namespace epAPI.DTOs
{
    [TsInterface]
    public class UserLoginResponseDTO
    {
        public string jwtToken { get; set; } = "";
        public UserDTO? userDTO { get; set; } = null;
        public string message { get; set; } = "";
    }
}
