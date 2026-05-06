using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Users
{
    public interface IUserService
    {
        Task<UserResponseDto> AddAsync(UserCreateDto dto);
        ICollection<UserResponseDto> GetAll();
        Task<UserResponseDto> GetByIdAsync(Guid userId);
        Task<UserResponseDto> UpdateAsync(Guid userId, UserUpdateDto dto);
        Task DeleteAsync(Guid userId);
    }
}
