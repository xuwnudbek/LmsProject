using System;

namespace LmsProjectApi.DTOs.Groups
{
    public class GroupUpdateDto
    {
        public string Name { get; set; }
        public Guid LevelId { get; set; }
        public Guid CourseId { get; set; }
    }
}
