using AutoMapper;
using MyTabs.API.Dto;
using MyTabs.API.Dtos;
using MyTabs.API.Model;

namespace MyTabs.API.Profiles
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