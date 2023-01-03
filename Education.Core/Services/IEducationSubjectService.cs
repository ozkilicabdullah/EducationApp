using Education.Core.Models;

namespace Education.Core.Services
{
    public interface IEducationSubjectService : IService<EducationSubject>
    {
        Task<List<EducationSubject>> GetEducationSubjectsByEducationId(int educationId);
    }
}
