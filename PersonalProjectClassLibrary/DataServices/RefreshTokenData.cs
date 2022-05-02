using PersonalProjectClassLibrary.DataAccess;
using PersonalProjectClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.DataServices
{
    public class RefreshTokenData : IRefreshTokenData
    {
        private readonly ISqlDataAccess _db;

        public RefreshTokenData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task InsertToken(RefreshToken refreshToken)
        {
            await _db.SaveData("dbo.spRefreshToken_Insert", refreshToken);
        }

        public async Task<RefreshToken> CheckToken(string token)
        {
            var result = await _db.LoadData<RefreshToken, dynamic>("dbo.spRefreshToken_GetByToken", new { Token = token });
            return result.FirstOrDefault();
        }
    }
}
