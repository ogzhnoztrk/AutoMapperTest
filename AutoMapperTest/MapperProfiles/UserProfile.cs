using AutoMapper;
using AutoMapperTest.Dtos;
using AutoMapperTest.Entities;

namespace AutoMapperTest.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.FullName, option => option.MapFrom(dest => dest.Name + " " + dest.LastName))
                .ForMember(dto => dto.Status, option => option.MapFrom(dest => ((UserStatus)dest.Status).ToString()));
        }
    }
}
