using LmsProjectApi.Enums;
using LmsProjectApi.Models.Attendances;
using LmsProjectApi.Models.Base;
using LmsProjectApi.Models.Courses;
using LmsProjectApi.Models.Payments;
using LmsProjectApi.Models.UserGroups;
using System.Collections.Generic;

namespace LmsProjectApi.Models.Users
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        public UserRole Role { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; } = new HashSet<UserGroup>();
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
        public ICollection<Attendance> Attendances { get; set; } = new HashSet<Attendance>();
        public ICollection<Payment> Payments { get; set; } = new HashSet<Payment>();
    }
}
