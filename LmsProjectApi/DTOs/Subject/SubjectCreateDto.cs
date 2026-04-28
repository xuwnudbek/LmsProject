using LmsProjectApi.DTOs.SubjectLevel;
using LmsProjectApi.Models.SubjectLevels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LmsProjectApi.DTOs.Subject
{
    public class SubjectCreateDto
    {
        [Required]
        public string  Name { get; set; }

        [Required]
        public bool HasLevel { get; set; }

        public ICollection<SubjectLevelCreateDto> Levels { get; set; }
    }
}
