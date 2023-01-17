using OutOfTheBox.Dto;

namespace OutOfTheBox.Logic.IServices
{
    public interface IReadService<T> where T : IDto
    {
        Task<IEnumerable<T>> ReadAllAsync();
        Task<T?> ReadByKeyAsync(object key);
        bool Exists(object key);
    }
}
