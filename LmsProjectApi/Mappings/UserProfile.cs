using AutoMapper;
using LmsProjectApi.DTOs.User;
using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Models;

namespace LmsProjectApi.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<UserResponseDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<ChangePasswordDto, User>();
            CreateMap<ChangeRoleDto, User>();
            CreateMap<ChangeStatusDto, User>();
        }
    }
}
