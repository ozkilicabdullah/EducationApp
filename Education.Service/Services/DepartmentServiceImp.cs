using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class DepartmentServiceImp : Service<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentServiceImp(IGenericRepository<Department> repository, IUnitOfWork unitOfWork, IDepartmentRepository departmentRepository) : base(repository, unitOfWork)
        {
            _departmentRepository = departmentRepository;
        }
    }
}
