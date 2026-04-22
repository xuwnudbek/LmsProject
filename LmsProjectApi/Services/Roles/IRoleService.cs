using LmsProjectApi.DTOs.Role;
using LmsProjectApi.Models;
using LmsProjectApi.Repositories.Roles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Roles
{
    public interface IRoleService
    {
        Task<RoleResponseDto> AddRoleAsync(RoleCreateDto role);
        Task<List<RoleResponseDto>> GetAllRolesAsync();
        Task<RoleResponseDto> GetRoleByIdAsync(Guid roleId);
        Task<RoleResponseDto> UpdateRoleAsync(Guid roleId, RoleUpdateDto role);
        Task DeleteRoleAsync(Guid roleId);
    }
}
