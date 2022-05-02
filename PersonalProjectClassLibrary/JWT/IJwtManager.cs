using PersonalProjectClassLibrary.ActionResults;
using PersonalProjectClassLibrary.Models;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.JWT
{
    public interface IJwtManager
    {
        Task<AuthenticationResult> Authenticate(UserModel user);

        Task<AuthenticationResult> RefreshToken(string token, string refreshToken);
    }
}