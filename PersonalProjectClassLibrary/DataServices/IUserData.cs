using PersonalProjectClassLibrary.Dto;
using PersonalProjectClassLibrary.Models;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.DataServices
{
    public interface IUserData
    {
        Task<UserModel> GetUser(string userEmail);

        Task InsertUser(UserSignUpDto userDto);
    }
}