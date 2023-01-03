using Education.Core.DTOs;
using Education.Core.Models;

namespace Education.Core.Repositories
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        Task<List<Answer>> GetQuestionAnswers(int questionId);
    }
}
