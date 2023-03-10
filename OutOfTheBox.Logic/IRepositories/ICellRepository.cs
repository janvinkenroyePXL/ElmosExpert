using OutOfTheBox.Domain;

namespace OutOfTheBox.Logic.IRepositories
{
    public interface ICellRepository : IRepository<Cell>
    {
        Task<IEnumerable<Cell>> GetFreeNonIsolationCellsAsync();
    }
}
