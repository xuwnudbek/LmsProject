using AutoMapper;
using LmsProjectApi.DTOs.Role;
using LmsProjectApi.Models;

namespace LmsProjectApi.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponseDto, Role>().ReverseMap();
            CreateMap<RoleCreateDto, Role>().ReverseMap();
            CreateMap<RoleUpdateDto, Role>().ReverseMap();
        }
    }
}
