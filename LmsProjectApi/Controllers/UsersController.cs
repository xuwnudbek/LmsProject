using AutoMapper;
using LmsProjectApi.DTOs.Users;
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
        public async Task<ActionResult<UserResponseDto>> CreateAsync(
            [FromBody] UserCreateDto dto)
        {
            UserResponseDto added =
                await _userService.AddUserAsync(dto);

            var userResponseDto =
                _mapper.Map<UserResponseDto>(added);

            return Created(string.Empty, userResponseDto);
        }

        [HttpGet]
        public ICollection<UserResponseDto> GetAllUsersAsync([FromQuery] UserRole role)
        {
            ICollection<UserResponseDto> users =
                _userService.GetAll(role);

            return users;
        }
    }
}
