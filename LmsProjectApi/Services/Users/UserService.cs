using AutoMapper;
using LmsProjectApi.DTOs.User;
using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Helpers;
using LmsProjectApi.Models;
using LmsProjectApi.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> AddUserAsync(UserCreateDto dto)
        {
            var existingUser =
                await _userRepository
                    .SelectUserByUsernameAsync(dto.Username);

            if (existingUser is not null)
                throw new UserAlreadyExistException();

            var user = _mapper.Map<User>(dto);

            var now = DateTime.UtcNow;

            user.PasswordHash = HashingHelper.GetHash(dto.Password);
            user.Id = Guid.NewGuid();
            user.IsActive = true;
            user.CreatedAt = now;
            user.UpdatedAt = now;

            await _userRepository.InsertUserAsync(user);

            return user;
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUserAsync(UserUpdateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
