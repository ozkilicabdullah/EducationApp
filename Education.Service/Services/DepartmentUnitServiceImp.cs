using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class DepartmentUnitServiceImp : Service<DepartmentUnit>, IDepartmentUnitService
    {
        private readonly IDepartmentUnitRepository _departmentUnitRepository;
        public DepartmentUnitServiceImp(IGenericRepository<DepartmentUnit> repository, IUnitOfWork unitOfWork, IDepartmentUnitRepository departmentUnitRepository) : base(repository, unitOfWork)
        {
            _departmentUnitRepository = departmentUnitRepository;
        }
    }
}
