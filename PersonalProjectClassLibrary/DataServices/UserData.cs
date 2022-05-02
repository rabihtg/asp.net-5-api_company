using PersonalProjectClassLibrary.DataAccess;
using PersonalProjectClassLibrary.Dto;
using PersonalProjectClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.DataServices
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<UserModel> GetUser(string userEmail)
        {
            var result = await _db.LoadData<UserModel, dynamic>("dbo.spUser_GetByEmail", new { Email = userEmail });
            return result.FirstOrDefault();
        }

        public async Task InsertUser(UserSignUpDto userDto)
        {
            var user = new UserModel
            {
                Id = Guid.NewGuid(),
                Email = userDto.Email,
                Password = userDto.Password
            };
            await _db.SaveData("dbo.spUser_Insert", user);
        }
    }
}
