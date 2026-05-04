using LmsProjectApi.DTOs.Groups;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Groups
{
    public interface IGroupService
    {
        Task<GroupResponseDto> AddAsync(GroupCreateDto dto);
        ICollection<GroupSimpleDto> GetAll();
        Task<GroupResponseDto> GetByIdAsync(Guid groupId);
        Task<GroupResponseDto> UpdateAsync(Guid groupId, GroupUpdateDto dto);
        Task DeleteAsync(Guid groupId);
    }
}
