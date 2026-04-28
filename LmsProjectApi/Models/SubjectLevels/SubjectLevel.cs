using LmsProjectApi.Models.Levels;
using LmsProjectApi.Models.Subjects;
using System;

namespace LmsProjectApi.Models.SubjectLevels
{
    public class SubjectLevel
    {
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }

        public Guid LevelId { get; set; }
        public Level Level { get; set; }

        public int OrderIndex { get; set; }
    }
}
