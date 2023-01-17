using AutoMapper;
using OutOfTheBox.Dto;
using OutOfTheBox.Enum;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Logic.Services
{
    public class ReleaseService : IReleaseService
    {
        private readonly IPrisonerRepository _repository;
        private readonly IMapper _mapper;
        public ReleaseService(IPrisonerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PrisonerDto?> ReleaseEarly(int prisonerId)
        {
            var prisoner = await _repository.GetByKeyAsync(prisonerId);
            if (prisoner == null)
            {
                return null;
            }
            prisoner.Status = PrisonerStatus.Released;
            return _mapper.Map<PrisonerDto>(await _repository.UpdateAsync(prisoner, prisoner.Id));
        }
    }
}
