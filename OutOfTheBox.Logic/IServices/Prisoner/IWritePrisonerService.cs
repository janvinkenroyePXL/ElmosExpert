using OutOfTheBox.Dto;

namespace OutOfTheBox.Logic.IServices
{
    public interface IWritePrisonerService : IWriteService<PrisonerDto, PrisonerCreateRequest, PrisonerUpdateRequest>
    {
    }
}
