using Education.Core.Models;

namespace Education.Core.Repositories
{
    public interface IUserRefreshTokenRepository : IGenericRepository<UserRefreshToken>
    {
        Task<UserRefreshToken> GetByUserId(int id);
        Task<UserRefreshToken> GetByRefreshToken(string refreshToken);
    }
}
