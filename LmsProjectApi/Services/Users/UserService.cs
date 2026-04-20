using AutoMapper;
using LmsProjectApi.DTOs.User;
using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Helpers;
using LmsProjectApi.Models;
using LmsProjectApi.Repositories.Roles;
using LmsProjectApi.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper, 
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<User> AddUserAsync(UserCreateDto dto, Guid roleId)
        {
            string normalizedUsername = 
                dto.Username.Trim().ToLowerInvariant();
            
            var existingUser = 
                await _userRepository
                    .SelectUserByUsernameAsync(normalizedUsername);

            if (existingUser is not null)
                throw new ConflictException($"User with username {dto.Username} already exists.");

            var user = _mapper.Map<User>(dto);

            var now = DateTime.UtcNow;

            user.Username = normalizedUsername;
            user.PasswordHash = HashingHelper.GetHash(dto.Password);
            user.Id = Guid.NewGuid();
            user.IsActive = true;
            user.CreatedAt = now;
            user.UpdatedAt = now;

            var existingRole = 
                await _roleRepository.SelectRoleByIdAsync(roleId);

            if (existingRole is null)
                throw new NotFoundException($"Role with id '{roleId}' not found.");

            user.RoleId = existingRole.Id;

            await _userRepository.InsertUserAsync(user);

            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            IQueryable<User> users = 
                _userRepository.SelectAllUsers();

            return users.ToList();
        }

        public async Task<User> GetUserById(Guid userId)
        {
            User existingUser = 
                await _userRepository.SelectUserByIdAsync(userId);

            if (existingUser is null)
                throw new NotFoundException("User not found.");

            return existingUser;
        }

        public async Task<User> UpdateUserAsync(Guid userId, UserUpdateDto dto)
        {
            User existingUser =
                await _userRepository.SelectUserByIdAsync(userId);

            if (existingUser is null)
                throw new NotFoundException("User not found.");



            await _userRepository.UpdateUserAsync();

            return existingUser;
        }

        public Task DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
