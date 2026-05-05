using LmsProjectApi.Enums;

namespace LmsProjectApi.DTOs.Users
{
    public class UserUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
