using OutOfTheBox.Domain;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Logic.Services
{
    public class CellAssignmentService : ICellAssignmentService
    {
        private readonly ICellRepository _cellRepository;
        private readonly IPrisonRepository _prisonRepository;

        public CellAssignmentService(ICellRepository cellRepository, IPrisonRepository prisonRepository)
        {
            _cellRepository = cellRepository;
            _prisonRepository = prisonRepository;
        }

        public async Task<Cell?> AssignCellToPrisoner(Prisoner prisoner)
        {
            var freeNonIsolationCells = await _cellRepository.GetFreeNonIsolationCellsAsync();
            if(freeNonIsolationCells == null)
            {
                return null;
            }
            else 
            {
                var freeCellsInFreePrisons = freeNonIsolationCells
                    .Where(c => _prisonRepository.GetNumberOfPrisonersAsync(c.PrisonId) < c.Prison!.Capacity);
                var r = new Random();
                if (!freeCellsInFreePrisons.Any())
                {
                    return freeNonIsolationCells.ElementAt(r.Next(0, freeNonIsolationCells.Count()));
                }
                return freeCellsInFreePrisons.ElementAt(r.Next(0, freeCellsInFreePrisons.Count()));
            }
        }
    }
}
