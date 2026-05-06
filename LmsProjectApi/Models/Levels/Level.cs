using LmsProjectApi.Models.Base;
using LmsProjectApi.Models.Groups;
using LmsProjectApi.Models.SubjectLevels;
using System.Collections.Generic;

namespace LmsProjectApi.Models.Levels
{
    public class Level : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<SubjectLevel> SubjectLevels { get; set; } = new HashSet<SubjectLevel>();
        public ICollection<Group> Groups { get; set; } = new HashSet<Group>();
    }
}
