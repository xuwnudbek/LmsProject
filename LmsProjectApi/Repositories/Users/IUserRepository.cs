using LmsProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> InsertUserAsync(User user);
        IQueryable<User> SelectAllUsers();
        IQueryable<User> SelectUsersByRoleId(Guid roleId);
        Task<User> SelectUserByIdAsync(Guid userId);
        Task<User> SelectUserByUsernameAsync(string username);
        Task UpdateUserAsync();
        Task DeleteUserAsync(Guid userId);
    }
}