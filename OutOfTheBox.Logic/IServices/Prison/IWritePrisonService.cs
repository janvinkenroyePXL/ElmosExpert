using OutOfTheBox.Dto;

namespace OutOfTheBox.Logic.IServices
{
    public interface IWritePrisonService : IWriteService<PrisonDto, PrisonCreateRequest, PrisonUpdateRequest>
    {
    }
}
