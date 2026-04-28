using LmsProjectApi.Models.SubjectLevels;
using System;
using System.Collections.Generic;

namespace LmsProjectApi.Models.Levels
{
    public class Level
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<SubjectLevel> SubjectLevels { get; set; }
    }
}
