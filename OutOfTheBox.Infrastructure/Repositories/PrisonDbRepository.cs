using OutOfTheBox.Domain;
using OutOfTheBox.Logic.IRepositories;

namespace OutOfTheBox.Infrastructure.Repositories
{
    public class PrisonDbRepository : BaseDbRepository<Prison>, IPrisonRepository
    {
        public PrisonDbRepository(OutOfTheBoxContext context) : base(context)
        {
        }
    }
}
