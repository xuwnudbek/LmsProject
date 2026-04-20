using AutoMapper;
using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Models;
using LmsProjectApi.Services.Users;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<UserResponseDto>> PostUserAsync(UserCreateDto dto)
        {
            User newUser = 
                await _userService.AddUserAsync(dto);

            var userResponseDto = _mapper.Map<UserResponseDto>(newUser);

            return CreatedAtAction(
                nameof(PostUserAsync),
                userResponseDto
            );
        } 
    }
}
