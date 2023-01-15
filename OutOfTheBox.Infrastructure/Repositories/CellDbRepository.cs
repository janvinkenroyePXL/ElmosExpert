using OutOfTheBox.Domain;
using OutOfTheBox.Logic.IRepositories;

namespace OutOfTheBox.Infrastructure.Repositories
{
    public class CellDbRepository : BaseDbRepository<Cell>, ICellRepository
    {
        public CellDbRepository(OutOfTheBoxContext context) : base(context)
        {
        }
    }
}
