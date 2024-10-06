using AutoMapper;
using dotnet_exam1.Src.DTOs;
using dotnet_exam1.Src.Models;

namespace dotnet_exam1.Src.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.Gender, opt => opt.Ignore())
                .ForMember(dest => dest.GenderId, opt => opt.Ignore());

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Name));

            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.Gender, opt => opt.Ignore())
                .ForMember(dest => dest.GenderId, opt => opt.Ignore());
        }
    }
}
