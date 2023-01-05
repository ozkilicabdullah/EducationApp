using Education.Core.Models;
using Education.Core.Repositories;
using Education.Core.Services;
using Education.Core.UnitOfWork;
using Education.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Education.Service.Services
{
    public class Service<T> : IService<T> where T : DbBaseEntity
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllWithPagingAsync(int pageNo, int pageSize)
        {
            return await _repository.GetAllWithPaging(pageNo, pageSize).ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var hasProduct = await _repository.GetByIdAsync(id);

            if (hasProduct == null)
            {
                throw new ClientSideException($"{typeof(T).Name}({id}) not found");
            }
            return hasProduct;
        }
        public async Task<int> GetTotalRecord()
        {
            return await _repository.GetTotalRecord();
        }
        public async Task RemoveAsync(T entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
        }
        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            var isExist = await _repository.AnyAsync(x => x.Id == entity.Id);
            if (isExist == false)
                throw new ClientSideException($"{typeof(T).Name}({entity.Id}) not found");
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
