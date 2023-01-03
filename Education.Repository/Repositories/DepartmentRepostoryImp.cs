using Education.Core.Models;
using Education.Core.Repositories;

namespace Education.Repository.Repositories
{
    public class DepartmentRepositoryImp : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepositoryImp(EducationDbContext context) : base(context)
        {
        }
    }
}
