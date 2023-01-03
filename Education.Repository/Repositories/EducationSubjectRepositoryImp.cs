using Education.Core.Models;
using Education.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Education.Repository.Repositories
{
    public class EducationSubjectRepositoryImp : GenericRepository<EducationSubject>, IEducationSubjectRepository
    {
        public EducationSubjectRepositoryImp(EducationDbContext context) : base(context)
        {
        }

        public async Task<List<EducationSubject>> GetEducationSubjectsByEducationId(int educationId)
        {
            List<EducationSubject> educationSubjects = new();

            var query = (from es in _context.EducationSubjects
                         join e in _context.Educations on es.EducationId equals e.Id
                         where es.Status == Status.Active && e.Status == Status.Active && e.Id == educationId
                         select es);
            educationSubjects = await query.ToListAsync();

            return educationSubjects;
        }
    }
}
