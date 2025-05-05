namespace JWTAndApi.DTO
{
    public class TokenResponseDto
    {
        public required string Token { get; set; }

        public DateTime TokenExpireDate { get; set; }
    }
}
