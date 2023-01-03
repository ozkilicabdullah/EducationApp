using Education.Core.UnitOfWork;

namespace Education.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EducationDbContext _context;

        public UnitOfWork(EducationDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
