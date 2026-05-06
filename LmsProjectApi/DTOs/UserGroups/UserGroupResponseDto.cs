using LmsProjectApi.DTOs.Groups;
using LmsProjectApi.DTOs.Users;

namespace LmsProjectApi.DTOs.UserGroups
{
    public class UserGroupResponseDto
    {
        public UserResponseDto User { get; set; }
        public GroupResponseDto Group { get; set; }
    }
}
