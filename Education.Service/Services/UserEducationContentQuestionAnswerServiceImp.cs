using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class UserEducationContentQuestionAnswerServiceImp : Service<UserEducationContentQuestionAnswer>, IUserEducationContentQuestionAnswerService
    {
        public UserEducationContentQuestionAnswerServiceImp(IGenericRepository<UserEducationContentQuestionAnswer> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
