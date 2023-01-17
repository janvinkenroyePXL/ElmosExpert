using OutOfTheBox.Domain;
using OutOfTheBox.Dto;

namespace OutOfTheBox.Logic.IServices
{
    public interface IIsolationService
    {
        Task<PrisonerDto?> StartIsolation(int prisonerId);
        Task<PrisonerDto?> StopIsolation(int prisonerId);
    }
}
