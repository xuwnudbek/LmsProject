using LmsProjectApi.Models.Base;
using System;

namespace LmsProjectApi.DTOs.Lessons
{
    public class LessonResponseDto : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CourseId { get; set; }

        //public Course Course { get; set; }
    }
}
