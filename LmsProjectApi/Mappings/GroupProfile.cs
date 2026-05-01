using AutoMapper;
using LmsProjectApi.DTOs.Groups;
using LmsProjectApi.Models.Groups;

namespace LmsProjectApi.Mappings
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupCreateDto, Group>();
            CreateMap<Group, GroupResponseDto>();
            CreateMap<GroupUpdateDto, Group>();
        }
    }
}
