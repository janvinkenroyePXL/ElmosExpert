using AutoMapper;
using OutOfTheBox.Domain;
using OutOfTheBox.Dto;
using OutOfTheBox.Logic.IRepositories;
using OutOfTheBox.Logic.IServices;

namespace OutOfTheBox.Logic.Services
{
    public class ReadCellService : BaseReadService<CellDto, Cell>, IReadCellService
    {
        public ReadCellService(ICellRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
