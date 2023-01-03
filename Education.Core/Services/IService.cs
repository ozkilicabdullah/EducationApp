using Education.Core.Models;
using System.Linq.Expressions;

namespace Education.Core.Services
{
    public interface IService<T> where T : DbBaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllWithPagingAsync(int pageNo, int pageSize);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
        Task<int> GetTotalRecord();
    }
}
