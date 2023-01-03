using Education.Core.Models;

namespace Education.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<User> GetUserByUserName(string userName);
        bool CheckPassword(User user, string password);
        Task<bool> UpdateUserPassword(User user, string password);
    }
}
