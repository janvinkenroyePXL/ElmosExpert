using OutOfTheBox.Domain;
using OutOfTheBox.Logic.IRepositories;

namespace OutOfTheBox.Infrastructure.Repositories
{
    public class PrisonDbRepository : BaseDbRepository<Prison>, IPrisonRepository
    {
        public PrisonDbRepository(OutOfTheBoxContext context) : base(context)
        {
        }

        public int GetNumberOfPrisonersAsync(object key)
        {
            return _context.Set<Prison>()
                .Where(p => p.Id == (int)key)
                .First()
                .Cells.Sum(c => c.Prisoners.Count);
        }
    }
}
