using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class UserExamQuestionAnswerServiceImp : Service<UserExamQuestionAnswer>, IUserExamQuestionAnswerService
    {
        public UserExamQuestionAnswerServiceImp(IGenericRepository<UserExamQuestionAnswer> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
