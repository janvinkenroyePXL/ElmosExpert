using AutoMapper;
using OutOfTheBox.Dto;
using OutOfTheBox.Enum;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Logic.Services
{
    public class IsolationService : IIsolationService
    {
        private readonly IPrisonerRepository _repository;
        private readonly IMapper _mapper;
        public IsolationService(IPrisonerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PrisonerDto?> StartIsolation(int prisonerId)
        {
            var prisoner = await _repository.GetByKeyAsync(prisonerId);
            if (prisoner == null)
            {
                return null;
            }
            prisoner.Status = PrisonerStatus.InIsolationCell;
            return _mapper.Map<PrisonerDto>(await _repository.UpdateAsync(prisoner, prisoner.Id));
        }

        public async Task<PrisonerDto?> StopIsolation(int prisonerId)
        {
            var prisoner = await _repository.GetByKeyAsync(prisonerId);
            if (prisoner == null)
            {
                return null;
            }
            prisoner.Status = PrisonerStatus.InNormalCell;
            return _mapper.Map<PrisonerDto>(await _repository.UpdateAsync(prisoner, prisoner.Id));
        }
    }
}
