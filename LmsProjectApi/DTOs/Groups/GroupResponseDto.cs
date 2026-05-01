using LmsProjectApi.DTOs.Courses;
using LmsProjectApi.DTOs.Levels;
using LmsProjectApi.DTOs.UserGroups;
using LmsProjectApi.Models.Courses;
using LmsProjectApi.Models.Levels;
using LmsProjectApi.Models.UserGroups;
using System;
using System.Collections.Generic;

namespace LmsProjectApi.DTOs.Groups
{
    public class GroupResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public LevelResponseDto Level { get; set; }
        public CourseResponseDto Course { get; set; }

        public ICollection<UserGroupResponseDto> UserGroups { get; set; } = new HashSet<UserGroupResponseDto>();
    }
}
