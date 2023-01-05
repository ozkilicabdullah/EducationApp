using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class UserEducationContentQuestionAnswersRepositoryImp : GenericRepository<UserEducationContentQuestionAnswer>, IUserEducationContentQuestionAnswersRepository
    {
        public UserEducationContentQuestionAnswersRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
