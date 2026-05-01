using AutoMapper;
using LmsProjectApi.DTOs.Courses;
using LmsProjectApi.Models.Courses;

namespace LmsProjectApi.Mappings
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseCreateDto, Course>()
                .ForMember(c => c.CreatedAt, opt => opt.Ignore())
                .ForMember(c => c.UpdatedAt, opt => opt.Ignore());

            CreateMap<Course, CourseResponseDto>();
            CreateMap<CourseUpdateDto, Course>();
        }
    }
}
