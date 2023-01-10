using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class IttestRepositoryImp : GenericRepository<ITTest>, IIttestRepository
    {
        public IttestRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
