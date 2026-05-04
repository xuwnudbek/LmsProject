using LmsProjectApi.Models.Base;
using LmsProjectApi.Models.Courses;
using LmsProjectApi.Models.Levels;
using LmsProjectApi.Models.UserGroups;
using System;
using System.Collections.Generic;

namespace LmsProjectApi.Models.Groups
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }

        public Guid LevelId { get; set; }
        public Level Level { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; } = new HashSet<UserGroup>();
    }
}
