using LmsProjectApi.Enums;
using LmsProjectApi.Models.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> InsertUserAsync(User user);
        IQueryable<User> SelectAllUsers();
        IQueryable<User> SelectUsersByRoleId(UserRole role);
        Task<User> SelectUserByIdAsync(Guid userId);
        Task<User> SelectUserByUsernameAsync(string username);
        Task UpdateUserAsync();
        Task DeleteUserAsync(Guid userId);
    }
}