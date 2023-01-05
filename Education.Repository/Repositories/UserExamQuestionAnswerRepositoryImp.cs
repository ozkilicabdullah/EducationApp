using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class UserExamQuestionAnswerRepositoryImp : GenericRepository<UserExamQuestionAnswer>, IUserExamQuestionAnswerRepository
    {
        public UserExamQuestionAnswerRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
