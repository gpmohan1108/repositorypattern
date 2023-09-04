
using AutoMapper;

namespace repositorypattern.Model
{
    public class AutoMapperprofile : Profile

    {
        public AutoMapperprofile()
        {
            CreateMap < Product, Viewproductmodel > ().ForMember(dest=> dest.PId, opt=>opt.MapFrom(src=>src.Id))
            .ForMember(dest => dest.PName, opt => opt.MapFrom(src => src.Name)).ReverseMap();
        }

        
    }
}
