using LmsProjectApi.Exceptions;
using LmsProjectApi.Models;
using LmsProjectApi.Repositories.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> AddRoleAsync(Role role)
        {
            Role newRole = 
                await _roleRepository.InsertRoleAsync(role);
            
            return newRole;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            List<Role> roles =
                await _roleRepository.SelectAllRolesAsync();

            return roles;
        }

        public async Task<Role> GetRoleByIdAsync(Guid roleId)
        {
            Role existingRole =
               await _roleRepository.SelectRoleByIdAsync(roleId);

            if (existingRole is null)
                throw new NotFoundException($"Role is not found with given id ({roleId})!");

            return existingRole;
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            Role existingRole =
               await _roleRepository.SelectRoleByIdAsync(role.Id);

            if (existingRole is null)
                throw new NotFoundException($"Role is not found with given id ({role.Id})!");

            Role updatedRole = await _roleRepository.UpdateRoleAsync(role);

            return updatedRole;
        }

        public async Task DeleteRoleAsync(Guid roleId)
        {
            Role existingRole =
               await _roleRepository.SelectRoleByIdAsync(roleId);

            if (existingRole is null)
                throw new NotFoundException($"Role is not found with given id ({roleId})!");

            await _roleRepository.DeleteRoleAsync(roleId);
        }
    }
}
