using AutoMapper;
using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Models.Users;

namespace LmsProjectApi.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<User, UserResponseDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<ChangePasswordDto, User>();
            CreateMap<ChangeRoleDto, User>();
            CreateMap<ChangeStatusDto, User>();
        }
    }
}
