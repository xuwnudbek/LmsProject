using AutoMapper;
using FluentValidation;
using LmsProjectApi.DTOs.Users;
using LmsProjectApi.Enums;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Helpers;
using LmsProjectApi.Models.Users;
using LmsProjectApi.Repositories.Users;
using LmsProjectApi.Validators.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserCreateDto> _userCreateValidator;
        private readonly IValidator<UserUpdateDto> _userUpdateValidator;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            IValidator<UserCreateDto> userCreateValidator,
            IValidator<UserUpdateDto> userUpdateValidator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userCreateValidator = userCreateValidator;
            _userUpdateValidator = userUpdateValidator;
        }

        public async Task<UserResponseDto> AddUserAsync(
            UserCreateDto dto)
        {
            var validatorResult = _userCreateValidator.Validate(dto);

            if (!validatorResult.IsValid)
                throw new Exceptions.ValidationException(validatorResult.Errors);

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

        public async Task<UserResponseDto> UpdateUserAsync(
            Guid userId,
            UserUpdateDto dto)
        {
            var validatorResult = _userUpdateValidator.Validate(dto);

            if (!validatorResult.IsValid)
                throw new Exceptions.ValidationException(validatorResult.Errors);

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
