using AutoMapper;
using LmsProjectApi.DTOs.SubjectLevel;
using LmsProjectApi.Models.SubjectLevels;

namespace LmsProjectApi.Mappings
{
    public class SubjectLevelProfile : Profile
    {
        public SubjectLevelProfile()
        {
            CreateMap<SubjectLevelCreateDto, SubjectLevel>()
                .ForMember(sl => sl.SubjectId, opt => opt.Ignore());

            CreateMap<SubjectLevel, SubjectLevelResponseDto>()
                .ForMember(sl => sl.LevelName,
                    opt => opt.MapFrom(src => src.Level.Name));

            CreateMap<SubjectLevelUpdateDto, SubjectLevel>()
                .ForMember(sl => sl.SubjectId, opt => opt.Ignore());
        }
    }
}
