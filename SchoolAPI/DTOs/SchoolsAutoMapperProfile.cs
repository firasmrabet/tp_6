using AutoMapper;
using SchoolAPI.Models;

namespace SchoolAPI.DTOs
{
    public class SchoolsAutoMapperProfile : Profile
    {
        public SchoolsAutoMapperProfile()
        {
            
            
            CreateMap<School, SchoolDto>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Sections));

            
            
            CreateMap<SchoolDto, School>()
                .ForMember(dest => dest.Sections, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Director, opt => opt.MapFrom(src => string.Empty))
                .ForMember(dest => dest.WebSite, opt => opt.MapFrom(src => (string?)null));
        }
    }
}

