using AutoMapper;
using LmsProjectApi.DTOs.LessonSessions;
using LmsProjectApi.Models.LessonSessions;

namespace LmsProjectApi.Mappings
{
    public class LessonSessionProfile : Profile
    {
        public LessonSessionProfile()
        {
            CreateMap<LessonSessionCreateDto, LessonSession>();
            CreateMap<LessonSession, LessonSessionResponseDto>();
            CreateMap<LessonSessionUpdateDto, LessonSession>();
        }
    }
}
