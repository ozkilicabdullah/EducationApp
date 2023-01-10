using Education.Core.DTOs;
using Education.Core.Models;
namespace Education.Core.Repositories
{
    public interface IExamQuestionsRepository : IGenericRepository<ExamQuestion>
    {
        Task<List<QuestionDto>> GetExamQuestion(int examId);
    }
}
