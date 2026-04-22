using LmsProjectApi.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LmsProjectApi.DTOs.User
{
    public class UserCreateDto
    {
        [Required, MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [Required, MinLength(13), MaxLength(13)]
        public string PhoneNumber { get; set; }

        [Required, MinLength(4), MaxLength(50)]
        public string Username { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        [Required, MinLength(8)]
        public string ConfirmPassword { get; set; }

        [Required]
        public Guid RoleId { get; set; }
    }
}
