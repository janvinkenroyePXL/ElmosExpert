using AutoMapper;
using OutOfTheBox.Domain;
using OutOfTheBox.Dto;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Logic.Services
{
    public class ReadPrisonerService : BaseReadService<PrisonerDto, Prisoner>, IReadPrisonerService
    {
        public ReadPrisonerService(IPrisonerRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
