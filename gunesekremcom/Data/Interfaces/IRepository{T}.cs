using gunesekremcom.Data.Entities;
using System.Linq.Expressions;

namespace gunesekremcom.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);

        Task<T?> GetByIdAsync(object id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T oldEntity, T newEntity);

        Task RemoveAsync(T entity);

        IQueryable<T> GetQuery();
    }
}
