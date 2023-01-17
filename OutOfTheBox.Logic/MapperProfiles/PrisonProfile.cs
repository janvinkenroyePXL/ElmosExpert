using AutoMapper;
using OutOfTheBox.Domain;
using OutOfTheBox.Dto;

namespace OutOfTheBox.Logic.MapperProfiles
{
    public class PrisonProfile : Profile
    {
        public PrisonProfile()
        {
            CreateMap<Prison, PrisonDto>();
            CreateMap<PrisonDto, Prison>();
            CreateMap<PrisonCreateRequest, Prison>();
            CreateMap<PrisonUpdateRequest, Prison>();
        }
    }
}
