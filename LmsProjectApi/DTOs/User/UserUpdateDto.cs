using System.ComponentModel.DataAnnotations;

namespace LmsProjectApi.DTOs.User
{
    public class UserUpdateDto
    {
        [Required, MinLength(2), MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MinLength(2), MaxLength(50)]
        public string LastName { get; set; }

        [Required, MinLength(13), MaxLength(13)]
        public string PhoneNumber { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string Username { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }

        [Required, MinLength(8)]
        public string ConfirmPassword { get; set; }
    }
}
