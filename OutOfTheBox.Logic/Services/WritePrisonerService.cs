using AutoMapper;
using OutOfTheBox.Domain;
using OutOfTheBox.Dto;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Logic.Services
{
    public class WritePrisonerService : BaseWriteService<Prisoner, PrisonerDto, PrisonerCreateRequest, PrisonerUpdateRequest>, IWritePrisonerService
    {
        public WritePrisonerService(IPrisonerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
