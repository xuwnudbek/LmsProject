using LmsProjectApi.Enums;
using LmsProjectApi.Models.Users;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Users
{
    public interface IUserRepository
    {
        Task<User> InsertAsync(User user);
        IQueryable<User> SelectAll();
        IQueryable<User> SelectByRole(UserRole role);
        Task<User> SelectByIdAsync(Guid userId);
        Task<User> SelectByUsernameAsync(string username);
        Task UpdateAsync();
        Task DeleteAsync(Guid userId);
    }
}