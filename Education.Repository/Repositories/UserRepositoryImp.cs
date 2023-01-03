using Education.Core.Models;
using Education.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Education.Repository.Repositories
{
    public class UserRepositoryImp : GenericRepository<User>, IUserRepository
    {
        public UserRepositoryImp(EducationDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var query = (from u in _context.Users where u.Email == userName select u);
            var user = await query.FirstOrDefaultAsync();
            return user;
        }
    }
}
