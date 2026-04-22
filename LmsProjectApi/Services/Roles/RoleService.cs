using AutoMapper;
using LmsProjectApi.DTOs.Role;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models;
using LmsProjectApi.Repositories.Roles;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(
            IRoleRepository roleRepository,
            IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleResponseDto> AddRoleAsync(RoleCreateDto dto)
        {
            Role existingRole =
                await _roleRepository.SelectRoleByNameAsync(dto.Name);

            if (existingRole is not null)
                throw new ConflictException($"Role {dto.Name} already exists.");

            Role role = _mapper.Map<Role>(dto);

            var newRole =
                await _roleRepository.InsertRoleAsync(role);

            return _mapper.Map<RoleResponseDto>(newRole);
        }

        public async Task<List<RoleResponseDto>> GetAllRolesAsync()
        {
            List<Role> roles =
                await _roleRepository.SelectAllRolesAsync();

            return _mapper.Map<List<RoleResponseDto>>(roles);
        }

        public async Task<RoleResponseDto> GetRoleByIdAsync(Guid roleId)
        {
            Role existingRole =
               await _roleRepository.SelectRoleByIdAsync(roleId);

            if (existingRole is null)
                throw new NotFoundException($"Role is not found with given id ({roleId})!");

            return _mapper.Map<RoleResponseDto>(existingRole);
        }

        public async Task<RoleResponseDto> UpdateRoleAsync(
            Guid roleId, RoleUpdateDto dto)
        {
            Role existingRoleWithId =
                await _roleRepository.SelectRoleByIdAsync(roleId);

            if (existingRoleWithId is null)
                throw new NotFoundException($"Role is not found with given id ({roleId})!");

            Role existingRoleWithName =
                await _roleRepository.SelectRoleByNameAsync(dto.Name);

            if (existingRoleWithName is not null)
                throw new ConflictException($"Role with name ({dto.Name}) already exists.");

            existingRoleWithId.Name = dto.Name;

            Role updatedRole =
                await _roleRepository.UpdateRoleAsync(existingRoleWithId);

            return _mapper.Map<RoleResponseDto>(updatedRole);
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
