using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class EducationRepositoryImp : GenericRepository<Core.Models.Education>, IEducationRepository
    {
        public EducationRepositoryImp(EducationDbContext context) : base(context)
        {
        } 
    }
}
