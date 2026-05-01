using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Users
{
    public interface IUserService
    {
        Task<UserResponseDto> AddUserAsync(UserCreateDto dto, UserRole authUserRole);
        ICollection<UserResponseDto> GetAll(UserRole role);
        Task<UserResponseDto> GetUserById(Guid userId);
        Task<UserResponseDto> UpdateUserAsync(Guid userId, UserUpdateDto dto);
        Task DeleteUserAsync(Guid userId);
    }
}
