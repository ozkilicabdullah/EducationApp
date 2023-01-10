using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class UserExamRepositoryImp : GenericRepository<UserExam>, IUserExamRepository
    {
        public UserExamRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
