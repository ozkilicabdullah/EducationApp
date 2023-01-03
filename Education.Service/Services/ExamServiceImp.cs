using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class ExamServiceImp : Service<Exam>, IExamService
    {
        private readonly IExamRepository _examRepository;
        public ExamServiceImp(IGenericRepository<Exam> repository, IUnitOfWork unitOfWork, IExamRepository examRepository) : base(repository, unitOfWork)
        {
            _examRepository = examRepository;
        }
    }
}
