using LmsProjectApi.DTOs.User;
using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Users
{
    public interface IUserService
    {
        Task<User> AddUserAsync(UserCreateDto dto);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid userId);
        Task<User> UpdateUserAsync(UserUpdateDto dto);
        Task<User> DeleteUserAsync(Guid userId);
    }
}
