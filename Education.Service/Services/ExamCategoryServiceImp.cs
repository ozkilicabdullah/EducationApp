using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class ExamCategoryServiceImp : Service<ExamCategory>, IExamCategoryService
    {
        private readonly IExamCategoryRepository _examCategoryRepository;
        public ExamCategoryServiceImp(IGenericRepository<ExamCategory> repository, IUnitOfWork unitOfWork, IExamCategoryRepository examCategoryRepository) : base(repository, unitOfWork)
        {
            _examCategoryRepository = examCategoryRepository;
        }
    }
}
