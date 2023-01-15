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

        public virtual T Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual T? Update(T entity, object key)
        {
            if (entity == null)
                return null;
            T? exist = _context.Set<T>().Find(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
            return exist;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }
    }
}
