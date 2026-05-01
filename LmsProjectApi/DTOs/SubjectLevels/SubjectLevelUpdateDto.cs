using System;

namespace LmsProjectApi.DTOs.SubjectLevel
{
    public class SubjectLevelUpdateDto
    {
        public Guid LevelId { get; set; }
        public int OrderIndex { get; set; }
    }
}
