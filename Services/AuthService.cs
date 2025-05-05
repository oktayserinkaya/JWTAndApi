using JWTAndApi.DTO;
using JWTAndApi.Interfaces;

namespace JWTAndApi.Services
{
    public class AuthService(ITokenService tokenService) : IAuthService
    {
        private readonly ITokenService _tokenService = tokenService;

        /*
         * RefreshToken VS AuthToken
         * 
         * AuthToken : API ye istek atmak için kullanacağımız kısa süreli token (45 dk - 2 saat)
         * RefreshToken : AuthToken süresi bittiğinde yenilenmesi için kullanılan uzun süreli token dır. (2 hafta)
         */

        public async Task<UserLoginResponseDto> LoginUserAsync(string userName)
        {
            //var loginResponse = request.UserName == "oktay" && request.Password == "123456";

            var generateTokenInfo = await _tokenService.GenerateTokenAsync(userName);

            var response = new UserLoginResponseDto
            {
                AccessTokenExpireDate = generateTokenInfo.TokenExpireDate,
                AuthenticationResult = true,
                AuthToken = generateTokenInfo.Token,
                RefreshToken = string.Empty,
                RefreshTokenEndDate = DateTime.Now
            };

            return response;
        }
    }
}
