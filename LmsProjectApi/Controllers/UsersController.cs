using AutoMapper;
using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Models.Api;
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
        public async Task<ActionResult<UserResponseDto>> CreateAsync(
            [FromBody] UserCreateDto dto)
        {
            UserResponseDto created =
                await _userService.AddAsync(dto);

            return Ok(ApiResponse<UserResponseDto>.Ok(created, "Successfully created."));
        }

        [HttpGet]
        public ActionResult<ICollection<UserResponseDto>> GetAllUsersAsync()
        {
            ICollection<UserResponseDto> users =
                _userService.GetAll();

            return Ok(ApiResponse<ICollection<UserResponseDto>>.Ok(users));
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserResponseDto>> GetById(Guid userId)
        {
            UserResponseDto user =
                await _userService.GetByIdAsync(userId);

            return Ok(ApiResponse<UserResponseDto>.Ok(user));
        }


        [HttpPut("{userId}")]
        public async Task<ActionResult<UserResponseDto>> UpdateAsync(
            Guid userId,
            [FromBody] UserUpdateDto dto)
        {
            UserResponseDto updated =
                await _userService.UpdateAsync(userId, dto);

            return Ok(ApiResponse<UserResponseDto>.Ok(updated, "Successfully updated."));
        }


        [HttpDelete("{userId}")]
        public async Task<ActionResult<UserResponseDto>> DeleteAsync(Guid userId)
        {
            await _userService.DeleteAsync(userId);

            return Ok(ApiResponse<object>.Ok(null!, "Successfully deleted."));

        }

    }
}
