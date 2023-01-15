using Microsoft.EntityFrameworkCore;
using OutOfTheBox.Logic.IRepositories;

namespace OutOfTheBox.Infrastructure.Repositories
{
    public abstract class BaseDbRepository<T> : IRepository<T> where T : class, new()
    {
        protected OutOfTheBoxContext _context;

        public BaseDbRepository(OutOfTheBoxContext context)
        {
            this._context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetByKeyAsync(object key)
        {
            return await _context.Set<T>().FindAsync(key);
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<T?> UpdateAsync(T entity, object key)
        {
            if (entity == null)
                return null;
            T? exist = _context.Set<T>().Find(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            return exist;
        }
    }
}
