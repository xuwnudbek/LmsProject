using AutoMapper;
using LmsProjectApi.DTOs.User;
using LmsProjectApi.Models;

namespace LmsProjectApi.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<UserResponseDto, User>().ReverseMap();
            CreateMap<UserUpdateDto, User>().ReverseMap();
            CreateMap<ChangePasswordDto, User>().ReverseMap();
            CreateMap<ChangeRoleDto, User>().ReverseMap();
            CreateMap<ChangeStatusDto, User>().ReverseMap();
        }
    }
}
