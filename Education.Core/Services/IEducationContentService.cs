using Education.Core.ViewModel;
using Education.Core.Models;
using Education.Core.DTOs;

namespace Education.Core.Services
{
    public interface IEducationContentService : IService<EducationContent>
    {
        /// <summary>
        /// Eğitim içeriği oluştururken ihtiyaç duyulan 'selectbox' verilerini döner
        /// </summary>
        /// <returns></returns>
        Task<CustomResponseDto<CreateEducationContentSelectItemDto>> GetCreateEducationContentSelectItems();
        /// <summary>
        /// İçerik türüne göre içerik listesi döner
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        Task<CustomResponseDto<EducationContentListDtoViewModel>> GetEducationContentsByContentType(ContentType contentType);
    }

}
