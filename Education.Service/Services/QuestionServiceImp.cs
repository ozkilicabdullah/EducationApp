using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class QuestionServiceImp : Service<Question>, IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionServiceImp(IGenericRepository<Question> repository, IUnitOfWork unitOfWork, IQuestionRepository questionRepository) : base(repository, unitOfWork)
        {
            _questionRepository = questionRepository;
        }
    }
}
