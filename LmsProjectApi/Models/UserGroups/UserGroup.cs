using LmsProjectApi.Models.Users;
using LmsProjectApi.Models.Groups;
using System;

namespace LmsProjectApi.Models.UserGroups
{
    public class UserGroup
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
