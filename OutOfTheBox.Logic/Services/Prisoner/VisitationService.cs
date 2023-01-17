using AutoMapper;
using OutOfTheBox.Dto;
using OutOfTheBox.Enum;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Logic.Services
{
    public class VisitationService : IVisitationService
    {
        private readonly IPrisonerRepository _repository;
        private readonly IMapper _mapper;
        public VisitationService(IPrisonerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PrisonerDto?> StartVisitation(int prisonerId)
        {
            var prisoner = await _repository.GetByKeyAsync(prisonerId);
            if (prisoner == null)
            {
                return null;
            }
            prisoner.Status = PrisonerStatus.InVisitorArea;
            return _mapper.Map<PrisonerDto>(await _repository.UpdateAsync(prisoner, prisoner.Id));
        }

        public async Task<PrisonerDto?> StopVisitation(int prisonerId)
        {
            var prisoner = await _repository.GetByKeyAsync(prisonerId);
            if(prisoner == null)
            {
                return null;
            }
            prisoner.Status = PrisonerStatus.InNormalCell;
            return _mapper.Map<PrisonerDto>(await _repository.UpdateAsync(prisoner, prisoner.Id));
        }
    }
}
