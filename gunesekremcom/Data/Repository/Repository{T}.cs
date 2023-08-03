using gunesekremcom.Data.Context;
using gunesekremcom.Data.Entities;
using gunesekremcom.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace gunesekremcom.Data.Repository
{
    public class Repository<T> : IRepository<T>
        where T : BaseEntity, new()
    {
        private readonly DatabaseContext context;
        public Repository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await context.Set<T>().Where(filter).AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> GetQuery()
        {
            return context.Set<T>().AsQueryable();
        }

        public async Task RemoveAsync(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public async Task UpdateAsync(T oldEntity, T newEntity)
        {
            context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }
    }
}
