using Microsoft.AspNetCore.Mvc;
using PersonalProjectClassLibrary.ActionResults;
using PersonalProjectClassLibrary.DataServices;
using PersonalProjectClassLibrary.Dto;
using PersonalProjectClassLibrary.JWT;
using PersonalProjectClassLibrary.Models;
using System.Threading.Tasks;

namespace PersonalProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserData _data;
        private readonly IJwtManager _jwt;

        public UserController(IUserData data, IJwtManager jwt)
        {
            _data = data;
            _jwt = jwt;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup(UserSignUpDto user)
        {
            await _data.InsertUser(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<AuthenticationResult> Authenticate(UserModel user)
        {
            return await _jwt.Authenticate(user);
        }

        [HttpPost("refresh")]
        public async Task<AuthenticationResult> Refresh(TokenModel token)
        {
            var authResult = await _jwt.RefreshToken(token.Token, token.RefreshToken);
            return authResult;
        }
    }
}
