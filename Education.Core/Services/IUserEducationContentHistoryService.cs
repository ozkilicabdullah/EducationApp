using Education.Core.DTOs;
using Education.Core.Models;

namespace Education.Core.Services
{
    public interface IUserEducationContentHistoryService : IService<UserEducationContentHistory>
    {
        /// <summary>
        /// Eğitim içeriğine ait aksiyonları döner
        /// </summary>
        Task<CustomResponseDto<EducationContentHistoryResponseDto>> GetEducationContentHistoryForUser(EducationContentHistoryUserRequestDto educationContentHistoryUserRequestDto);

        /// <summary>
        /// Eğitime ait tüm içeriklerdeki aksiyon verilerini döner
        /// </summary>
        Task<CustomResponseDto<List<EducationContentHistoryResponseDto>>> GetEducationContentsHistoryForUser(EducationContentsHistoryUserRequestDto educationContentsHistoryUserRequestDto);

    }
}
