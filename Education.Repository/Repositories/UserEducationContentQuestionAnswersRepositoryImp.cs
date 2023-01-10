using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class UserEducationContentQuestionAnswerRepositoryImp : GenericRepository<UserEducationContentQuestionAnswer>, IUserEducationContentQuestionAnswerRepository
    {
        public UserEducationContentQuestionAnswerRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
