using AutoMapper;
using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Enums;
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

        public async Task<UserResponseDto> AddUserAsync(
            UserCreateDto dto,
            UserRole authUserRole)
        {
            string normalizedUsername =
                dto.Username.Trim().ToLowerInvariant();

            var existingUser =
                await _userRepository
                    .SelectUserByUsernameAsync(normalizedUsername);

            if (existingUser is not null)
                throw new ConflictException($"User with username ({dto.Username}) already exists.");

            var user = _mapper.Map<User>(dto);

            var now = DateTimeOffset.UtcNow;

            user.Username = normalizedUsername;
            user.PasswordHash = HashingHelper.GetHash(dto.Password);
            user.Id = Guid.NewGuid();
            user.IsActive = true;
            user.CreatedAt = now;
            user.UpdatedAt = now;


            User newUser = await _userRepository.InsertUserAsync(user);

            return _mapper.Map<UserResponseDto>(newUser);
        }

        public ICollection<UserResponseDto> GetAll(
            UserRole role)
        {
            IQueryable<User> users = 
                _userRepository.SelectAllUsers()
                .Where(u => u.Role == role);

            //if (authUserRole is UserRole.Manager)
            //{
            //    users = users.Where(
            //        u => u.Role != UserRole.Admin &&
            //        u.Role == role);
            //}

            return _mapper.Map<ICollection<UserResponseDto>>(users);
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

        public async Task DeleteUserAsync(Guid userId)
        {
            User existingUser =
                await _userRepository.SelectUserByIdAsync(userId);

            if (existingUser is null)
                throw new NotFoundException("User not found.");

            await _userRepository.DeleteUserAsync(userId);
        }
    }
}
