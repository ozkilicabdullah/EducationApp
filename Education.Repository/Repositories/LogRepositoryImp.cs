
using Education.Core.Models;
using Education.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Education.Repository.Repositories
{
    public class LogRepositoryImp : ILogRepository
    {
        protected readonly EducationDbContext _context;
        private readonly DbSet<Log> _dbSet;

        public LogRepositoryImp(EducationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Log>();
        }

        public void AddLog(Log log)
        {
            _dbSet.Add(log);
        }
    }
}
