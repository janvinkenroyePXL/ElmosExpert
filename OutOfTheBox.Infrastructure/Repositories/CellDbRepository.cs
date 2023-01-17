using Microsoft.EntityFrameworkCore;
using OutOfTheBox.Domain;
using OutOfTheBox.Logic.IRepositories;

namespace OutOfTheBox.Infrastructure.Repositories
{
    public class CellDbRepository : BaseDbRepository<Cell>, ICellRepository
    {
        public CellDbRepository(OutOfTheBoxContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Cell>> GetAllAsync()
        {
            return await _context.Set<Cell>()
                .Include(c => c.Prison)
                .Include(c => c.Prisoners)
                .ToListAsync();
        }

        public async override Task<Cell?> GetByKeyAsync(object key)
        {
            return await _context.Set<Cell>()
                .Include(c => c.Prison)
                .Include(c => c.Prisoners)
                .FirstOrDefaultAsync(c => c.Id == (int) key);
        }

        public async Task<IEnumerable<Cell>> GetFreeNonIsolationCellsAsync()
        {
            return await _context.Set<Cell>()
                .Where(c => c.IsIsolationCell == false
                    && c.Prisoners.Count < c.Capacity)
                .ToListAsync();
        }
    }
}
