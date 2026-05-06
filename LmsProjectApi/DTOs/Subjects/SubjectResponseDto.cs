using LmsProjectApi.DTOs.SubjectLevel;
using System;
using System.Collections.Generic;

namespace LmsProjectApi.DTOs.Subjects
{
    public class SubjectResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool HasLevel { get; set; }

        public ICollection<SubjectLevelResponseDto> Levels { get; set; }
    }
}
