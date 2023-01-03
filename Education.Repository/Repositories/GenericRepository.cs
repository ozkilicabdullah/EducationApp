using Education.Core.Models;
using Education.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Education.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : DbBaseEntity
    {

        protected readonly EducationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(EducationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(x => x.Status == Status.Active).AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<T> GetAllWithPaging(int pageNo, int pageSize)
        {
            return _dbSet.Skip((pageNo - 1) * pageSize).Where(x => x.Status == Status.Active).Take(pageSize).AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Status == Status.Active);
        }

        public Task<int> GetTotalRecord()
        {
            return _dbSet.Where(x => x.Status == Status.Active).CountAsync();
        }

        public void Remove(T entity)
        {
            entity.Status = Status.Removed;
            _dbSet.Update(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AsNoTracking().Where(expression);
        }
    }
}
