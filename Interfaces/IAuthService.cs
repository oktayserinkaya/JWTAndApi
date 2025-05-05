using JWTAndApi.DTO;

namespace JWTAndApi.Interfaces
{
    public interface IAuthService
    {
        Task<UserLoginResponseDto> LoginUserAsync(string userName);
    }
}
