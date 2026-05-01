using LmsProjectApi.Models.Courses;
using LmsProjectApi.Models.SubjectLevels;
using System;
using System.Collections.Generic;

namespace LmsProjectApi.Models.Subjects
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool HasLevel { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public ICollection<SubjectLevel> SubjectLevels { get; set; } = new HashSet<SubjectLevel>();
        public ICollection<Course> Courses { get; set; } = new HashSet<Course>();

    }
}