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
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    
        public ICollection<SubjectLevel> SubjectLevels { get; set; }
    }
}