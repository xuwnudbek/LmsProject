using LmsProjectApi.Enums;
using System;

namespace LmsProjectApi.DTOs.Users
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public UserRole Role { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
