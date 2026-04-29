using LmsProjectApi.Enums;
using LmsProjectApi.Models.UserGroups;
using System;
using System.Collections.Generic;

namespace LmsProjectApi.Models.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public string  PhoneNumber { get; set; }
        public string  Username { get; set; }
        public string  PasswordHash { get; set; }
        public bool  IsActive { get; set; }
        public string  ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public UserRole Role { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }
    }
}
