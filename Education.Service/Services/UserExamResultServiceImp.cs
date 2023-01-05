using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class UserExamResultServiceImp : Service<UserExamResult>, IUserExamResultService
    {
        public UserExamResultServiceImp(IGenericRepository<UserExamResult> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
