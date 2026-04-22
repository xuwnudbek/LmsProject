using AutoMapper;
using LmsProjectApi.DTOs.User;
using LmsProjectApi.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<UserResponseDto>> PostUserAsync(
            [FromBody] UserCreateDto dto)
        {
            UserResponseDto newUser =
                await _userService.AddUserAsync(dto);

            var userResponseDto =
                _mapper.Map<UserResponseDto>(newUser);

            return Created(string.Empty, userResponseDto);
        }

        [HttpGet]
        public async Task<List<UserResponseDto>> GetAllUsersAsync()
        {
            List<UserResponseDto> users =
                await _userService.GetAllUsersAsync();

            return users;
        }
    }
}
