using Microsoft.EntityFrameworkCore;
using OutOfTheBox.Domain;
using OutOfTheBox.Logic.IRepositories;

namespace OutOfTheBox.Infrastructure.Repositories
{
    public class PrisonerDbRepository : BaseDbRepository<Prisoner>, IPrisonerRepository
    {
        public PrisonerDbRepository(OutOfTheBoxContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Prisoner>> GetAllAsync()
        {
            return await _context.Set<Prisoner>()
                .Include(p => p.Sentence)
                .Include(p => p.Cell)
                .ThenInclude(c => c!.Prison)
                .ToListAsync();
        }

        public async override Task<Prisoner?> GetByKeyAsync(object key)
        {
            return await _context.Set<Prisoner>()
                .Include(p => p.Sentence)
                .FirstOrDefaultAsync(c => c.Id == (int)key);
        }
    }
}
