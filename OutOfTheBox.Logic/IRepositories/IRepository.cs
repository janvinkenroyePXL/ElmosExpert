namespace OutOfTheBox.Logic.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByKeyAsync(object key);
        Task<T> InsertAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<T?> UpdateAsync(T entity, object key);
    }
}
