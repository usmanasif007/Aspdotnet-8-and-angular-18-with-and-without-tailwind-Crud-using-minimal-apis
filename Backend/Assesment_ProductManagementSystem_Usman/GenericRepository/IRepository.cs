using System.Linq.Expressions;

namespace Assesment_ProductManagementSystem_Usman.GenericRepository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();

        Task<T> AddAsync(T entity);
        Task<List<T>> AddRangeAsync(List<T> entity);

        Task<T> UpdateAsync(T entity);
        Task<List<T>> UpdateRangeAsync(List<T> entity);

        Task<T> GetAsync(T id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

        void Remove(T entity);
        Task RemoveAsync(Expression<Func<T, bool>> predicate);
        void RemoveRange(List<T> entities);

        Task<long> CountAsync(Expression<Func<T, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }

}
