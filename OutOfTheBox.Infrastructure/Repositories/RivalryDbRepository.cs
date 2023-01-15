using OutOfTheBox.Domain;
using OutOfTheBox.Logic.IRepositories;

namespace OutOfTheBox.Infrastructure.Repositories
{
    public class RivalryDbRepository : BaseDbRepository<Rivalry>, IRivalryRepository
    {
        public RivalryDbRepository(OutOfTheBoxContext context) : base(context)
        {
        }
    }
}
