using Education.Core.DTOs;

namespace Education.Core.Services
{
    public interface IEducationService : IService<Models.Education>
    {
        /// <summary>
        /// Eğitim oluştururken ihtiyaç duyulacak combobox verilerini içerir.
        /// </summary>
        /// <returns></returns>
        Task<CreateEducationSelectItemsDto> GetCreateEducationSelectItems();
    }
}
