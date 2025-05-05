using JWTAndApi.DTO;

namespace JWTAndApi.Interfaces
{
    public interface ITokenService
    {
        Task<TokenResponseDto> GenerateTokenAsync(string userName);
    }
}
