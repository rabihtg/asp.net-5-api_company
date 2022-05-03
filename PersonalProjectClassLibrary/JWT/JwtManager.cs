using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PersonalProjectClassLibrary.ActionResults;
using PersonalProjectClassLibrary.DataServices;
using PersonalProjectClassLibrary.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProjectClassLibrary.JWT
{
    public class JwtManager : IJwtManager
    {
        private readonly IConfiguration _config;
        private readonly IUserData _data;
        private readonly IRefreshTokenData _tokenData;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtManager(IConfiguration config, IUserData data, 
            TokenValidationParameters tokenValidationParameters, IRefreshTokenData tokenData)
        {
            _config = config;
            _data = data;
            _tokenValidationParameters = tokenValidationParameters;
            _tokenData = tokenData;
        }

        public async Task<AuthenticationResult> Authenticate(UserModel user)
        {
            var checkUser = await _data.GetUser(user.Email);

            if (checkUser is null)
            {
                return new AuthenticationResult
                {
                    Error = "User not found.",
                    StatusCode = ((int)HttpStatusCode.BadRequest)
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JWT:Key"]);
            var refreshKey = Encoding.ASCII.GetBytes(_config["JWT:RefreshKey"]);

            var tokenOptions = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, checkUser.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("age", checkUser.Age.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(TimeSpan.Parse(_config["JWT:TokenLifeTime"]).Minutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var refreshTokenOptions = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(refreshKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenOptions);

            var refreshToken = tokenHandler.CreateToken(refreshTokenOptions);



            var newRefreshToken = new RefreshToken
            {
                CreatedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(4),
                JwtId = token.Id,
                Token = tokenHandler.WriteToken(refreshToken),
                UserId = checkUser.Id
            };

            Console.WriteLine(newRefreshToken.ExpiryDate.ToString());
            Console.WriteLine(newRefreshToken.ExpiryDate.ToShortDateString());

            await _tokenData.InsertToken(newRefreshToken);

            return new AuthenticationResult
            {
                StatusCode = 200,
                Token = new TokenModel()
                {
                    Token = tokenHandler.WriteToken(token),
                    RefreshToken = newRefreshToken.Token
                }
            };
        }

        public async Task<AuthenticationResult> RefreshToken(string token, string refreshToken)
        {
            var claimsPrincipal = GetPricipal(token);

            if(claimsPrincipal is null)
            {
                return new AuthenticationResult
                {
                    Error = "Invalid Token",
                    StatusCode = ((int)HttpStatusCode.BadRequest)
                };
            }

            var expiryDateUnix = long.Parse(claimsPrincipal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);
            
            var expiryDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(expiryDateUnix);

            if(expiryDate > DateTime.UtcNow)
            {
                return new AuthenticationResult
                {
                    Error = "Token Still Valid can't Issue another"
                };
            }

            var jti = claimsPrincipal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            var storedRefreshToken = await _tokenData.CheckToken(refreshToken);

            if(storedRefreshToken is null)
            {
                return new AuthenticationResult { Error = "Refresh Token Not Valid", StatusCode = 400};
            }
            if(DateTime.UtcNow > storedRefreshToken.ExpiryDate)
            {
                return new AuthenticationResult { Error = "Refresh Token Expired", StatusCode = 400 };
            }

            if(!storedRefreshToken.JwtId.Equals(jti, StringComparison.InvariantCultureIgnoreCase))
            {
                return new AuthenticationResult
                {
                    Error = $"Token Id mismatch jti: {jti}, jwtId: {storedRefreshToken.JwtId}",
                    StatusCode = 400
                };
            }

            var user = await _data.GetUser(claimsPrincipal.Claims.Single(x => x.Type == ClaimTypes.Email).Value);
            return await Authenticate(user);
        }

        private ClaimsPrincipal GetPricipal(string token)
        {
            var tokenHanlder = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHanlder.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                if(!ValidateAlgorithm(validatedToken))
                {
                    return null;
                }
                return principal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        private static bool ValidateAlgorithm(SecurityToken token)
        {
            return (token is JwtSecurityToken jwtSecurityToken) && 
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
