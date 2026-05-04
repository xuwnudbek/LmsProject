using LmsProjectApi.Models.Base;
using LmsProjectApi.Models.SubjectLevels;
using System;
using System.Collections.Generic;

namespace LmsProjectApi.Models.Levels
{
    public class Level : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<SubjectLevel> SubjectLevels { get; set; } = new HashSet<SubjectLevel>();
    }
}
