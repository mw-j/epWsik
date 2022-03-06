using System.Text.Json.Serialization;

namespace epDataAccess.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        [JsonIgnore]
        public string Password { get; set; } =  "";
    }
}
