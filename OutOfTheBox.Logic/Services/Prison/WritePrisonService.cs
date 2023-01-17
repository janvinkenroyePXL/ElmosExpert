using AutoMapper;
using OutOfTheBox.Domain;
using OutOfTheBox.Dto;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Logic.Services
{
    public class WritePrisonService : BaseWriteService<Prison, PrisonDto, PrisonCreateRequest, PrisonUpdateRequest>, IWritePrisonService
    {
        public WritePrisonService(IPrisonRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
