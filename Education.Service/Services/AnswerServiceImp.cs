using Education.Core.DTOs;
using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;
using Education.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Education.Service.Services
{
    public class AnswerServiceImp : Service<Answer>, IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IQuestionRepository _questionRepository;

        public AnswerServiceImp(IGenericRepository<Answer> repository, IUnitOfWork unitOfWork, IAnswerRepository answerRepository, IQuestionRepository questionRepository) : base(repository, unitOfWork)
        {
            _answerRepository = answerRepository;
            _questionRepository = questionRepository;
        }

        public async Task<List<Answer>> GetQuestionAnswers(int questionId)
        {
            return await _answerRepository.GetQuestionAnswers(questionId);
        }

        /// <summary>
        /// Soru oluşturma kuralları 
        /// 1 sorunun 5 adetten fazla cevabı olamaz
        /// 1 sorunun 1 tane doğru cevabı olabilir.
        /// </summary>
        /// <param name="answerCreateDto"></param>
        /// <returns></returns>
        public async Task<CheckRulesDto> CheckCreateAnswerRules(AnswerCreateDto answerCreateDto)
        {
            // gönderilen istekte belirtilen sorun Id'sine ait soru mevcut mu? 
            await _questionRepository.GetByIdAsync(answerCreateDto.QuestionId);

            var questionAnswers = await _answerRepository.Where(x =>
                                                 x.QuestionId == answerCreateDto.QuestionId
                                                 && x.Status == Status.Active).ToListAsync();
            if (questionAnswers != null && questionAnswers.Count() > 0)
            {
                if (questionAnswers.Count() == 5)
                    throw new ClientSideException($"A Questions can have a maximum of 5 answers.");

                if (questionAnswers.Any(x => x.IsCorrect == true))
                    throw new ClientSideException($"This Questions has a correct answer! A Questions cannot have more than one correct answer!");
            }
            return CheckRulesDto.Success();
        }

        /// <summary>
        /// 1 sorunun 1 tane doğru cevabı olabilir.
        /// </summary>
        /// <param name="answerUpdateDto"></param>
        /// <returns></returns>
        /// <exception cref="ClientSideException"></exception>
        public async Task<CheckRulesDto> CheckUpdateAnswerRules(AnswerUpdateDto answerUpdateDto)
        {
            // gönderilen istekte belirtilen sorun Id'sine ait soru mevcut mu? 
            await _questionRepository.GetByIdAsync(answerUpdateDto.QuestionId);

            var questionAnswers = await _answerRepository.Where(x =>
                                                 x.QuestionId == answerUpdateDto.QuestionId
                                                 && x.Status == Status.Active).ToListAsync();

            if (questionAnswers != null && questionAnswers.Count() > 0)
            {
                var answer = questionAnswers.Where(x => x.IsCorrect == true).FirstOrDefault();
                // Yanlış cevap güncelleniyorsa
                if (answer != null && !answer.IsCorrect)
                {
                    // Yanlış cevap doğru olarak işaretlenecek ise
                    if (answerUpdateDto.IsCorrect)
                    {
                        // mevcutta soruya ait başka bir doğru cevap varsa
                        if (questionAnswers.Any(x => x.IsCorrect == true))
                            throw new ClientSideException($"There is a correct answer to the Questions. Please update the correct answer as incorrect first!");
                    }
                }
            }

            return CheckRulesDto.Success();
        }

    }
}
