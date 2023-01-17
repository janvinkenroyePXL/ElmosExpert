using OutOfTheBox.Domain;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Logic.Services
{
    public class CellAssignmentService : ICellAssignmentService
    {
        private readonly ICellRepository _repository;

        public CellAssignmentService(ICellRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cell?> AssignCellToPrisoner(Prisoner prisoner)
        {
            var freeNonIsolationCells = await _repository.GetFreeNonIsolationCellsAsync();
            if(freeNonIsolationCells == null)
            {
                return null;
            }
            else
            {
                var r = new Random();
                return freeNonIsolationCells.ElementAt(r.Next(0, freeNonIsolationCells.Count()));
            }
        }
    }
}
