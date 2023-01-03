using Education.Core.Models;
using Education.Core.ViewModel;

namespace Education.Core.Services
{
    public interface IExamQuestionsService : IService<ExamQuestion>
    {
        /// <summary>
        /// Sınav için çoklu soru ekleme
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        Task<CustomResponseDto<NoContentDto>> AddQuestionsForExam(ExamQuestionCreatePayloadDto requestModel);
    }
}
