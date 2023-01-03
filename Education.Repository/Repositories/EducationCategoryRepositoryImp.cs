using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class EducationCategoryRepositoryImp : GenericRepository<EducationCategory>, IEducationCategoryRepository
    {
        public EducationCategoryRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
