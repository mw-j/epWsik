﻿namespace epAPI.DTOs
{
    [TsInterface]
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
}
