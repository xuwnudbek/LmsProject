using AutoMapper;
using LmsProjectApi.DTOs.Levels;
using LmsProjectApi.Models.Levels;

namespace LmsProjectApi.Mappings
{
    public class LevelProfile : Profile
    {
        public LevelProfile()
        {
            CreateMap<LevelCreateDto, Level>();
            CreateMap<Level, LevelResponseDto>();
            CreateMap<LevelUpdateDto, Level>();
        }
    }
}
