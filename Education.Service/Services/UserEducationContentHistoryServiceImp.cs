using Education.Core;
using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    /// <summary>
    /// Eğitim içeriklerinin kullanıcı aksiyonları
    /// </summary>
    public class UserEducationContentHistoryServiceImp : Service<UserEducationContentHistory>, IUserEducationContentHistoryService
    {
        private readonly IUserEducationContentHistoryRepository _userEducationContentHistoryRepository;
        public UserEducationContentHistoryServiceImp(IGenericRepository<UserEducationContentHistory> repository, IUnitOfWork unitOfWork, IUserEducationContentHistoryRepository userEducationContentHistoryRepository) : base(repository, unitOfWork)
        {
            _userEducationContentHistoryRepository = userEducationContentHistoryRepository;
        }

        public async Task<CustomResponseDto<EducationContentHistoryResponseDto>> GetEducationContentHistoryForUser(EducationContentHistoryUserRequestDto educationContentHistoryUserRequestDto)
        {
            var response = await _userEducationContentHistoryRepository.GetEducationContentHistoryForUser(educationContentHistoryUserRequestDto);
            if (response == null)
                return CustomResponseDto<EducationContentHistoryResponseDto>.Fail(400, "Record not found!");
            return CustomResponseDto<EducationContentHistoryResponseDto>.Success(200, response);
        }

        public async Task<CustomResponseDto<List<EducationContentHistoryResponseDto>>> GetEducationContentsHistoryForUser(EducationContentsHistoryUserRequestDto educationContentsHistoryUserRequestDto)
        {
            var response = await _userEducationContentHistoryRepository.GetEducationContentsHistoryForUser(educationContentsHistoryUserRequestDto);
            if (response == null)
                return CustomResponseDto<List<EducationContentHistoryResponseDto>>.Fail(400, "Record not found!");
            return CustomResponseDto<List<EducationContentHistoryResponseDto>>.Success(200, response);
        }
    }
}
