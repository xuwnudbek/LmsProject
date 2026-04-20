using LmsProjectApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Roles
{
    public interface IRoleRepository
    {
        Task<Role> InsertRoleAsync(Role role);
        Task<List<Role>> SelectAllRolesAsync();
        Task<Role> SelectRoleByIdAsync(Guid roleId);
        Task<Role> UpdateRoleAsync(Role role);
        Task<Role> DeleteRoleAsync(Guid roleId);
    }
}
