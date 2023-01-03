using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;

namespace Education.Service.Services
{
    public class EducationSubjectServiceImp : Service<EducationSubject>, IEducationSubjectService
    {
        private readonly IEducationSubjectRepository _educationSubjectRepository;
        public EducationSubjectServiceImp(IGenericRepository<EducationSubject> repository, IUnitOfWork unitOfWork, IEducationSubjectRepository educationSubjectRepository) : base(repository, unitOfWork)
        {
            _educationSubjectRepository = educationSubjectRepository;
        }

        public async Task<List<EducationSubject>> GetEducationSubjectsByEducationId(int educationId)
        {
            return await _educationSubjectRepository.GetEducationSubjectsByEducationId(educationId);
        }
    }
}
