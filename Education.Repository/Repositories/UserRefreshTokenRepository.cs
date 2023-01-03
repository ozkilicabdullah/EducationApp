using Education.Core.Models;
using Education.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Education.Repository.Repositories
{
    public class UserRefreshTokenRepository : GenericRepository<UserRefreshToken>, IUserRefreshTokenRepository
    {
        public UserRefreshTokenRepository(EducationDbContext context) : base(context)
        {
        }

        public async Task<UserRefreshToken> GetByRefreshToken(string refreshToken)
        {
            var query = (from rt in _context.UserRefreshTokens where rt.RefreshToken == refreshToken select rt);
            var userRefreshToken = await query.FirstOrDefaultAsync();
            return userRefreshToken;
        }

        public async Task<UserRefreshToken> GetByUserId(int id)
        {
            var query = (from rt in _context.UserRefreshTokens where rt.UserId == id select rt);
            var userRefreshToken = await query.FirstOrDefaultAsync();
            return userRefreshToken;
        }
    }
}
