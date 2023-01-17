using OutOfTheBox.Domain;
using OutOfTheBox.Dto;

namespace OutOfTheBox.Logic.IServices
{
    public interface IReleaseService
    {
        Task<PrisonerDto?> ReleaseEarly(int prisonerId);
    }
}
