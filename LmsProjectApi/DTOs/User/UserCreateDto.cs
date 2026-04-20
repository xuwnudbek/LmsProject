using LmsProjectApi.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace LmsProjectApi.DTOs.Users
{
    public class UserCreateDto
    {
        [Required, MinLength(3), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string LastName { get; set; }

        [Required, StringLength(13, MinimumLength = 13)]
        public string PhoneNumber { get; set; }

        [Required, MinLength(4), MaxLength(50)]
        public string Username { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        [Required, MinLength(8)]
        public string ConfirmPassword { get; set; }
    }
}
