using OutOfTheBox.Domain;

namespace OutOfTheBox.Logic.IServices
{
    public interface ICellAssignmentService
    {
        Task<Cell?> AssignCellToPrisoner(Prisoner prisoner);
    }
}
