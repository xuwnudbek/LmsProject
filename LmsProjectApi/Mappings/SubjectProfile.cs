using AutoMapper;
using LmsProjectApi.DTOs.Subjects;
using LmsProjectApi.Models.Subjects;

namespace LmsProjectApi.Mappings
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<SubjectCreateDto, Subject>()
                .ForMember(s => s.SubjectLevels,
                    opt => opt.Ignore());

            CreateMap<Subject, SubjectResponseDto>()
                .ForMember(srd => srd.Levels,
                    opt => opt.MapFrom(src => src.SubjectLevels));

            CreateMap<Subject, SubjectSimpleDto>();
            CreateMap<SubjectUpdateDto, Subject>();
        }
    }
}
