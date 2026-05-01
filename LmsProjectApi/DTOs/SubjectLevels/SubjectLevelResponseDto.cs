using System;

namespace LmsProjectApi.DTOs.SubjectLevel
{
    public class SubjectLevelResponseDto
    {
        public Guid LevelId { get; set; }
        public string LevelName { get; set; }
        public int OrderIndex { get; set; }
    }
}

