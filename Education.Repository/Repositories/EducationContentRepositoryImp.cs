using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class EducationContentRepositoryImp : GenericRepository<EducationContent>, IEducationContentRepository
    {
        public EducationContentRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
