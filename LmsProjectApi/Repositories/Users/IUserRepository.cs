using LmsProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> InsertUserAsync(User user);
        List<User> SelectAllUsersAsync();
        Task<User> SelectUserByIdAsync(Guid userId);
        Task<User> SelectUserByUsernameAsync(string username);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(Guid userId);
    }
}
