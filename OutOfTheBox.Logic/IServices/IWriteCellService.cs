using OutOfTheBox.Dto;

namespace OutOfTheBox.Logic.IServices
{
    public interface IWriteCellService : IWriteService<CellDto, CellCreateRequest, CellUpdateRequest>
    {
    }
}
