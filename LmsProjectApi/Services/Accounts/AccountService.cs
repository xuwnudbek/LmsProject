using FluentValidation;
using LmsProjectApi.Helpers;
using LmsProjectApi.Models.UserCredentials;
using LmsProjectApi.Models.Users;
using LmsProjectApi.Models.UserTokens;
using LmsProjectApi.Repositories.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IValidator<UserCredential> _credentialValidator;

        public AccountService(
            IUserRepository userRepository,
            IConfiguration configuration,
            IValidator<UserCredential> credentialValidator)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _credentialValidator = credentialValidator;
        }

        public async Task<UserToken> LoginAsync(UserCredential userCredential)
        {
            var validationResult = _credentialValidator.Validate(userCredential);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult.Errors);

            User existingUser =
                await _userRepository.SelectByUsernameAsync(userCredential.Username);

            if (existingUser is null)
                throw new Exceptions.ValidationException("Invalid login credentials");

            bool isValidPassword =
                HashingHelper.Verify(userCredential.Password, existingUser.PasswordHash);

            if (isValidPassword is not true)
                throw new Exceptions.ValidationException("Invalid login credentials");

            return GenerateUserToken(existingUser);
        }

        private UserToken GenerateUserToken(User user)
        {
            string secretKey = _configuration["AuthConfiguration:Key"];
            string issuer = _configuration["AuthConfiguration:Issuer"];
            string audience = _configuration["AuthConfiguration:Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            var expirationDate = DateTime.UtcNow.AddMinutes(15);

            var securityToken = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expirationDate,
                signingCredentials: credentials
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return new UserToken
            {
                Token = tokenString,
                ExpirationDate = expirationDate,
            };
        }
    }
}
