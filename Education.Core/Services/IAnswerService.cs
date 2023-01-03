using Education.Core.DTOs;
using Education.Core.Models;
using System.Runtime.CompilerServices;

namespace Education.Core.Services
{
    public interface IAnswerService : IService<Answer>
    {
        /// <summary>
        /// Sorunun cevaplarını döner
        /// </summary>
        /// <param name="questionId">Soru birincil anahatarı</param>
        /// <returns></returns>
        Task<List<Answer>> GetQuestionAnswers(int questionId);
        /// <summary>
        /// Soru oluşturma kuralları 
        /// 1 sorunun 5 adetten fazla cevabı olamaz
        /// 1 sorunun 1 tane doğru cevabı olabilir.
        /// </summary>
        /// <param name="answerCreateDto"></param>
        /// <returns></returns>
        Task<CheckRulesDto> CheckCreateAnswerRules(AnswerCreateDto answerCreateDto);
        /// <summary>
        /// 1 sorunun 1 tane doğru cevabı olabilir.
        /// </summary>
        /// <param name="answerUpdateDto"></param>
        /// <returns></returns>
        /// <exception cref="ClientSideException"></exception>
        Task<CheckRulesDto> CheckUpdateAnswerRules(AnswerUpdateDto answerUpdateDto);
    }
}
