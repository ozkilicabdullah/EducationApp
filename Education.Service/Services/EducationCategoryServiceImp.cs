using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class EducationCategoryServiceImp : Service<EducationCategory>, IEducationCategoryService
    {
        private readonly IEducationCategoryRepository _educationCategoryRepository;
        public EducationCategoryServiceImp(IGenericRepository<EducationCategory> repository, IUnitOfWork unitOfWork, IEducationCategoryRepository educationCategoryRepository) : base(repository, unitOfWork)
        {
            _educationCategoryRepository = educationCategoryRepository;
        }
    }
}
