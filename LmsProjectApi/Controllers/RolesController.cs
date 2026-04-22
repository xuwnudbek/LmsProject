using LmsProjectApi.DTOs.Role;
using LmsProjectApi.Models;
using LmsProjectApi.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<ActionResult<RoleResponseDto>> PostRoleAsync(
            [FromBody] RoleCreateDto dto)
        {
            RoleResponseDto newRole = 
                await _roleService.AddRoleAsync(dto);

            return Ok(newRole);
        }

        [HttpGet]
        public async Task<List<RoleResponseDto>> GetAllRolesAsync()
        {
            List<RoleResponseDto> roles = 
                await _roleService.GetAllRolesAsync();

            return roles;
        }

        [HttpGet("{roleId}")]
        public async Task<RoleResponseDto> GetRoleByIdAsync(Guid roleId)
        {
            RoleResponseDto existingRole =
                await _roleService.GetRoleByIdAsync(roleId);

            return existingRole;
        }


    }
}
