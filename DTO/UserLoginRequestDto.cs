namespace JWTAndApi.DTO
{
    public class UserLoginRequestDto
    {
        public required string UserName { get; set; }

        public required string Password { get; set; }
    }
}
