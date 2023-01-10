using Education.Core.DTOs;
using Education.Core.ViewModel;

namespace Education.Core.Services
{
    public interface IEducationService : IService<Models.Education>
    {
        /// <summary>
        /// Eğitim oluştururken ihtiyaç duyulacak combobox verilerini içerir.
        /// </summary>
        /// <returns></returns>
        Task<CreateEducationSelectItemsDto> GetCreateEducationSelectItems();
        /// <summary>
        /// Kullanıcıya atanmış eğitimleri döner
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<CustomResponseDto<GetMyAssignedEducationPayloadDto>> GetMyAssignedEducation(int userId);
    }
}
