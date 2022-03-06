using epDataAccess.Models;

namespace epDataAccess.Data
{
    public interface IUserData
    {
        Task DeleteUser(Guid userId);
        Task<UserModel?> GetUser(Guid userId);
        Task<UserModel?> GetUserByEmail(string email);
        Task<IEnumerable<UserModel>> GetUsers();
        Task InsertUser(UserModel user);
        Task UpdateUser(UserModel user);
    }
}