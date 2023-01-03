using Education.Core.DTOs;
using Education.Core.Models;
namespace Education.Core.Repositories
{
    public interface IUserEducationContentHistoryRepository : IGenericRepository<UserEducationContentHistory>
    {
        /// <summary>
        /// Kullanıcı, eğitim içeriği ve kullanıcnın eğitim içeriği üzerindeki aksiyon bilgilerini döner
        /// </summary>
        /// <param name="educationContentHistoryUserRequestDto"></param>
        /// <returns></returns>
        Task<EducationContentHistoryResponseDto> GetEducationContentHistoryForUser(EducationContentHistoryUserRequestDto educationContentHistoryUserRequestDto);

        /// <summary>
        /// Kullanıcı, eğitime ait tüm eğitim içerikleri, ve her eğitim içeriği üzerinden yapılan aksiyon bilgilerini döner
        /// </summary>
        /// <param name="educationContentsHistoryUserRequestDto"></param>
        /// <returns></returns>
        Task<List<EducationContentHistoryResponseDto>> GetEducationContentsHistoryForUser(EducationContentsHistoryUserRequestDto educationContentsHistoryUserRequestDto);
    }
}
