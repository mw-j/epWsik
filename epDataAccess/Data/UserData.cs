using epDataAccess.DbAccess;
using epDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epDataAccess.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<UserModel>> GetUsers() =>
            _db.LoadData<UserModel, dynamic>("dbo.sp_User_GetAll", new { });

        public async Task<UserModel?> GetUser(Guid userId)
        {
            var results = await _db.LoadData<UserModel, dynamic>(
                "dbo.sp_User_Get",
                new { userId });

            return results.FirstOrDefault();
        }

        public Task InsertUser(UserModel user) =>
            _db.SaveData("dbo.sp_User_Insert", new { user.FirstName, user.LastName });

        public Task UpdateUser(UserModel user) =>
            _db.SaveData("dbo.sp_User_Update", user);

        public Task DeleteUser(Guid userId) =>
            _db.SaveData("dbo.sp_User_Delete", new { userId });
    }
}
