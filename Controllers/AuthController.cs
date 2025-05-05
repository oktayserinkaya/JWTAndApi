using JWTAndApi.DTO;
using JWTAndApi.Interfaces;
using JWTAndApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAndApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserLoginResponseDto>> LoginUser([FromBody] UserLoginRequestDto request)
        {
            if (request.UserName == "oktay" && request.Password == "123456")
            {
                var result = await _authService.LoginUserAsync(request.UserName);
                return Ok(result);
            }

            return BadRequest("Kullanıcı Adı Veya Şifre Yanlış");
        }
    }
}
