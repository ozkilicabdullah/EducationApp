

namespace Education.Auth.Dtos
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToke { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
