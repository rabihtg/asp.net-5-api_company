using PersonalProjectClassLibrary.Models;
using System;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.DataServices
{
    public interface IRefreshTokenData
    {
        Task<RefreshToken> CheckToken(string token);
        Task InsertToken(RefreshToken token);
    }
}