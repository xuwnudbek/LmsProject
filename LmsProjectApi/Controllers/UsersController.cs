using AutoMapper;
using LmsProjectApi.DTOs.User;
using LmsProjectApi.Enums;
using LmsProjectApi.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LmsProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Teacher,Student")]
        public async Task<ActionResult<UserResponseDto>> PostUserAsync(
            [FromBody] UserCreateDto dto)
        {
            var authUserRole =
                Enum.Parse<UserRole>(User.FindFirst(ClaimTypes.Role).Value);

            UserResponseDto newUser =
                await _userService.AddUserAsync(dto, authUserRole);

            var userResponseDto =
                _mapper.Map<UserResponseDto>(newUser);

            return Created(string.Empty, userResponseDto);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Teacher,Student")]
        public async Task<List<UserResponseDto>> GetAllUsersAsync([FromQuery] UserRole role)
        {
            var authUserRole =
                Enum.Parse<UserRole>(User.FindFirst(ClaimTypes.Role).Value);

            List<UserResponseDto> users =
                await _userService.GetAllAsync(authUserRole, role);

            return users;
        }
    }
}
