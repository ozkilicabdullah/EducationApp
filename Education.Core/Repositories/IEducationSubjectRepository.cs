using Education.Core.Models;

namespace Education.Core.Repositories
{
    public interface IEducationSubjectRepository : IGenericRepository<EducationSubject>
    {
        Task<List<EducationSubject>> GetEducationSubjectsByEducationId(int educationId);
    }
}
