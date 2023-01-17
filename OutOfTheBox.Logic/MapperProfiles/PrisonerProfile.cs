using AutoMapper;
using OutOfTheBox.Domain;
using OutOfTheBox.Dto;

namespace OutOfTheBox.Logic.MapperProfiles
{
    public class PrisonerProfile : Profile
    {
        public PrisonerProfile()
        {
            CreateMap<Prisoner, PrisonerDto>();
            CreateMap<PrisonerDto, Prisoner>();
            CreateMap<PrisonerCreateRequest, Prisoner>();
            CreateMap<PrisonerUpdateRequest, Prisoner>();
        }
    }
}
