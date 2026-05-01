using LmsProjectApi.DTOs.SubjectLevel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LmsProjectApi.DTOs.Subjects
{
    public class SubjectUpdateDto
    {
        public string Name { get; set; }
        public bool HasLevel { get; set; }
        public ICollection<SubjectLevelUpdateDto> Levels { get; set; }
    }
}
