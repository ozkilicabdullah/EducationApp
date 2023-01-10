using Education.Core.Models;
using Education.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Services
{
    public interface IUserExamService : IService<UserExam>
    {
        /// <summary>
        /// Eğitim içeriğinde çıkan sorulara verilen yanıtın kayıt edilmesi
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        Task<CustomResponseDto<NoContentDto>> AddAnswerForEducationContentQuestion(EducationContentQuestionAnswerRequestPayloadDto requestModel);
        /// <summary>
        /// Kullanıcının sınav sorularına verdiği yanıtın kayıt edilmesi
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        Task<CustomResponseDto<NoContentDto>> AddExamAnswersForUser(AddExamQuestionAnswersRequestPayloadDto requestModel);
        /// <summary>
        /// Kullanıcılara sınav atama
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        Task<CustomResponseDto<NoContentDto>> AssignExamForUsers(AssignExamForUsersRequestDto requestModel);
    }
}
