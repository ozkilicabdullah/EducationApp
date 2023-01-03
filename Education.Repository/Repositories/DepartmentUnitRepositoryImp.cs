
using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class DepartmentUnitRepositoryImp : GenericRepository<DepartmentUnit>, IDepartmentUnitRepository
    {
        public DepartmentUnitRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
