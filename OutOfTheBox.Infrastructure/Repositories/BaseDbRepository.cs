using Microsoft.EntityFrameworkCore;
using OutOfTheBox.Domain;
using OutOfTheBox.Logic.IRepositories;

namespace OutOfTheBox.Infrastructure.Repositories
{
    public abstract class BaseDbRepository<T> : IRepository<T> where T : class, IEntity, new()
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

        public virtual async Task<T?> InsertAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            var idProperty = entity.GetType().GetProperty("Id")?.GetValue(entity, null);
            return await _context.Set<T>().FindAsync(idProperty);
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T?> UpdateAsync(T entity, object key)
        {
            if (entity == null)
                return null;
            T? exist = await _context.Set<T>().FindAsync(key);
            if (exist != null)
            {
                entity.Id = exist.Id;
                _context.Entry(exist).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
            return exist;
        }

        public virtual bool Exists(object key)
        {
            return _context.Set<T>().Find(key) != null;
        }
    }
}
