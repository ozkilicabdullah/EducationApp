using Education.Core;
using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;
using Education.Core.ViewModel;

namespace Education.Service.Services
{
    public class UserServiceImp : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UserServiceImp(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            return await _userRepository.GetUserByUserName(userName);
        }

        public bool CheckPassword(User user, string password)
        {
            if (user == null || string.IsNullOrEmpty(password))
                return false;

            if (user.Password == SecureOperations.MD5Hash(password))
                return true;

            return false;
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateUserPassword(User user, ChangePasswordDto changePasswordDto)
        {
            if (CheckPassword(user, changePasswordDto.oldPassword))
            {
                user.Password = SecureOperations.MD5Hash(changePasswordDto.newPassword);
                _userRepository.Update(user);
                await _unitOfWork.CommitAsync();
                return CustomResponseDto<NoContentDto>.Success(200);
            }
            return CustomResponseDto<NoContentDto>.Fail(400, "Old password is incorrect!");
        }
    }
}
