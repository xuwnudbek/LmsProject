using LmsProjectApi.DTOs.SubjectLevel;
using LmsProjectApi.Models.SubjectLevels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LmsProjectApi.DTOs.Subjects
{
    public class SubjectCreateDto
    {
        public string Name { get; set; }
        public bool HasLevel { get; set; }

        public ICollection<Guid> Levels { get; set; }
    }
}
