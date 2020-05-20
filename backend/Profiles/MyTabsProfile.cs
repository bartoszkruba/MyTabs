using AutoMapper;
using backend.Dto;
using backend.Model;

namespace backend.Profiles
{
    public class MyTabsProfile : Profile
    {
        public MyTabsProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();
        }
    }
}