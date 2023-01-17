using AutoMapper;
using OutOfTheBox.Domain;
using OutOfTheBox.Dto;
using OutOfTheBox.Enum;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Logic.Services
{
    public class WritePrisonerService : BaseWriteService<Prisoner, PrisonerDto, PrisonerCreateRequest, PrisonerUpdateRequest>, IWritePrisonerService
    {
        private readonly IPrisonerRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICellAssignmentService _cellAssignmentService;

        public WritePrisonerService(IPrisonerRepository repository, 
            IMapper mapper, 
            ICellAssignmentService cellAssignmentService) 
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _cellAssignmentService = cellAssignmentService;
        }

        public override async Task<PrisonerDto?> CreateAsync(PrisonerCreateRequest createRequest)
        {
            var prisoner = _mapper.Map<Prisoner>(createRequest);
            prisoner.Cell = await _cellAssignmentService.AssignCellToPrisoner(prisoner);
            prisoner.Status = PrisonerStatus.InNormalCell;
            var returnedEntity = await _repository.InsertAsync(prisoner);
            return _mapper.Map<PrisonerDto>(returnedEntity);
        }
    }
}
