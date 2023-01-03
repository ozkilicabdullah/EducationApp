using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class UserRefreshTokenServiceImp : Service<UserRefreshToken>, IUserRefreshTokenService
    {
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;
        public UserRefreshTokenServiceImp(IGenericRepository<UserRefreshToken> repository, IUnitOfWork unitOfWork, IUserRefreshTokenRepository userRefreshTokenRepository) : base(repository, unitOfWork)
        {
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public async Task<UserRefreshToken> GetByRefreshToken(string refreshToken)
        {
            return await _userRefreshTokenRepository.GetByRefreshToken(refreshToken);
        }

        public async Task<UserRefreshToken> GetByUserId(int id)
        {
            return await _userRefreshTokenRepository.GetByUserId(id);
        }
    }
}
