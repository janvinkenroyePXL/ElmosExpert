using AutoMapper;
using OutOfTheBox.Domain;
using OutOfTheBox.Dto;

namespace OutOfTheBox.Logic.MapperProfiles
{
    public class CellProfile : Profile
    {
        public CellProfile()
        {
            CreateMap<Cell, CellDto>();
            CreateMap<CellDto, Cell>();
            CreateMap<CellCreateRequest, Cell>();
            CreateMap<CellUpdateRequest, Cell>();
        }
    }
}
