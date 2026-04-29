using System;

namespace LmsProjectApi.DTOs.Subject
{
    public class SubjectSimpleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool HasLevel { get; set; }
    }
}
