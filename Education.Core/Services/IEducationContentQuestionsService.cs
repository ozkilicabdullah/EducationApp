using Education.Core.Models;
using Education.Core.ViewModel;

namespace Education.Core.Services
{
    public interface IEducationContentQuestionsService : IService<EducationContentQuestion>
    {
        /// <summary>
        /// Eğitim içeriğine çoklu soru ekleme
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        Task<CustomResponseDto<NoContentDto>> AddQuestionsForEducation(EducationContentQuestionCreatePayloadDto requestModel);
    }
}
