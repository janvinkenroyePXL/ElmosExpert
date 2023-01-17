using OutOfTheBox.Domain;

namespace OutOfTheBox.Logic.IRepositories
{
    public interface IPrisonRepository : IRepository<Prison>
    {
        int GetNumberOfPrisonersAsync(object key);
    }
}
