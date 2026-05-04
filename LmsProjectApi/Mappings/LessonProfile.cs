using AutoMapper;
using LmsProjectApi.DTOs.Lessons;
using LmsProjectApi.Models.Lessons;

namespace LmsProjectApi.Mappings
{
    public class LessonProfile : Profile
    {
        public LessonProfile()
        {
            CreateMap<LessonCreateDto, Lesson>();
            CreateMap<Lesson, LessonResponseDto>();
            CreateMap<LessonUpdateDto, Lesson>();
        }
    }
}
