using Education.Core.Models;
using Education.Core.ViewModel;

namespace Education.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<User> GetUserByUserName(string userName);
        bool CheckPassword(User user, string password);
        Task<CustomResponseDto<NoContentDto>> UpdateUserPassword(User user, ChangePasswordDto changePasswordDto);
    }
}
