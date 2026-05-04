using LmsProjectApi.Models.Base;
using LmsProjectApi.Models.Groups;
using LmsProjectApi.Models.Lessons;
using LmsProjectApi.Models.Levels;
using LmsProjectApi.Models.Subjects;
using LmsProjectApi.Models.Users;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LmsProjectApi.Models.Courses
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public ICollection<Lesson> Lessons { get; set; } = new HashSet<Lesson>();
        public ICollection<Group> Groups { get; set; } = new HashSet<Group>();

    }
}
