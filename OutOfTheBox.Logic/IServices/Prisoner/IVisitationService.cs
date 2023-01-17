using OutOfTheBox.Domain;
using OutOfTheBox.Dto;

namespace OutOfTheBox.Logic.IServices
{
    public interface IVisitationService
    {
        Task<PrisonerDto?> StartVisitation(int prisonerId);
        Task<PrisonerDto?> StopVisitation(int prisonerId);
    }
}
