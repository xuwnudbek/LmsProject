using LmsProjectApi.DTOs.Role;
using System;

namespace LmsProjectApi.DTOs.User
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public RoleResponseDto Role { get; set; }
    }
}
