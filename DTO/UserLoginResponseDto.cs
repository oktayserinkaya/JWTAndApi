namespace JWTAndApi.DTO
{
    public class UserLoginResponseDto
    {
        public bool AuthenticationResult { get; set; }

        public string AuthToken { get; set; }

        public DateTime AccessTokenExpireDate { get; set; }

        public required string RefreshToken { get; set; }

        public DateTime RefreshTokenEndDate { get; set; }
    }
}
