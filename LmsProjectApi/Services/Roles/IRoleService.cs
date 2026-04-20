using LmsProjectApi.Models;
using LmsProjectApi.Repositories.Roles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Roles
{
    public interface IRoleService
    {
        Task<Role> AddRoleAsync(Role role);
        Task<List<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(Guid roleId);
        Task<Role> UpdateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(Guid roleId);
    }
}
