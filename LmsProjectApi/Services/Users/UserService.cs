using AutoMapper;
using LmsProjectApi.DTOs.User;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Helpers;
using LmsProjectApi.Models.Users;
using LmsProjectApi.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> AddUserAsync(UserCreateDto dto)
        {
            string normalizedUsername = 
                dto.Username.Trim().ToLowerInvariant();
            
            var existingUser = 
                await _userRepository
                    .SelectUserByUsernameAsync(normalizedUsername);

            if (existingUser is not null)
                throw new ConflictException($"User with username ({dto.Username}) already exists.");

            var user = _mapper.Map<User>(dto);

            var now = DateTime.UtcNow;

            user.Username = normalizedUsername;
            user.PasswordHash = HashingHelper.GetHash(dto.Password);
            user.Id = Guid.NewGuid();
            user.IsActive = true;
            user.CreatedAt = now;
            user.UpdatedAt = now;


            User newUser = await _userRepository.InsertUserAsync(user);

            return _mapper.Map<UserResponseDto>(newUser);
        }
            
        public async Task<List<UserResponseDto>> GetAllUsersAsync()
        {
            IQueryable<User> users = 
                _userRepository.SelectAllUsers();

            return _mapper.Map<List<UserResponseDto>>(users);
        }

        public async Task<UserResponseDto> GetUserById(Guid userId)
        {
            User existingUser = 
                await _userRepository.SelectUserByIdAsync(userId);

            if (existingUser is null)
                throw new NotFoundException("User not found.");

            return _mapper.Map<UserResponseDto>(existingUser);
        }

        public async Task<UserResponseDto> UpdateUserAsync(Guid userId, UserUpdateDto dto)
        {
            User existingUser =
                await _userRepository.SelectUserByIdAsync(userId);

            if (existingUser is null)
                throw new NotFoundException("User not found.");

            await _userRepository.UpdateUserAsync();

            return _mapper.Map<UserResponseDto>(existingUser);
        }

        public Task DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
