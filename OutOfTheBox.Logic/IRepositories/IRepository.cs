namespace OutOfTheBox.Logic.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByKeyAsync(object key);
        T Insert(T entity);
        void Delete(T entity);
        T? Update(T entity, object key);
        void Save();
    }
}
