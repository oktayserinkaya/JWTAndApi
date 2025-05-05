using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAndApi.DTO;
using JWTAndApi.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace JWTAndApi.Services
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        private readonly IConfiguration _configuration = configuration;

        public Task<TokenResponseDto> GenerateTokenAsync(string userName)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenSettings:SecretKey"] ?? ""));

            var token = new JwtSecurityToken
            (
                issuer: _configuration["TokenSettings:ValidIssuer"],
                audience: _configuration["TokenSettings:ValidAudience"],
                claims:
                [
                    new Claim("username",userName),
                ],
                notBefore: DateTime.Now,
                expires: DateTime.Now.Add(TimeSpan.FromMinutes(500)),
                signingCredentials: new SigningCredentials
                (
                    symmetricSecurityKey,
                    SecurityAlgorithms.HmacSha256
                )
            );

            return Task.FromResult(new TokenResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                TokenExpireDate = DateTime.Now.Add(TimeSpan.FromMinutes(500))
            });
        }
    }
}
