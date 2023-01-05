using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class UserExamResultRepositoryImp : GenericRepository<UserExamResult>, IUserExamResultRepository
    {
        public UserExamResultRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
