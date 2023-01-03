using Education.Core.Models;

namespace Education.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByUserName(string userName);
    }
}
