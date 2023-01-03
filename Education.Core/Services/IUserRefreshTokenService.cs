using Education.Core.Models;

namespace Education.Core.Services
{
    public interface IUserRefreshTokenService : IService<UserRefreshToken>
    {
        Task<UserRefreshToken> GetByUserId(int id);
        Task<UserRefreshToken> GetByRefreshToken(string refreshToken);
    }
}
