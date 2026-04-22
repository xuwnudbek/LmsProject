using LmsProjectApi.DTOs.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Users
{
    public interface IUserService
    {
        Task<UserResponseDto> AddUserAsync(UserCreateDto dto);
        Task<List<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto> GetUserById(Guid userId);
        Task<UserResponseDto> UpdateUserAsync(Guid userId, UserUpdateDto dto);
        Task DeleteUserAsync(Guid userId);
    }
}
