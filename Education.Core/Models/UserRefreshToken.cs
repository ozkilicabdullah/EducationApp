namespace Education.Core.Models
{
    public class UserRefreshToken : DbBaseEntity
    {
        public int UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
