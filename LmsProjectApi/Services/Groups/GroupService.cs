using AutoMapper;
using LmsProjectApi.DTOs.Groups;
using LmsProjectApi.DTOs.Levels;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models.Groups;
using LmsProjectApi.Models.Levels;
using LmsProjectApi.Repositories.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Groups
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(
            IGroupRepository groupRepository,
            IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<GroupResponseDto> AddAsync(GroupCreateDto dto)
        {
            Group group = _mapper.Map<Group>(dto);

            Group inserted =
                await _groupRepository.InsertAsync(group);

            return _mapper.Map<GroupResponseDto>(inserted);
        }

        public ICollection<GroupSimpleDto> GetAll()
        {
            ICollection<Group> groups = 
                _groupRepository
                    .SelectAll()
                    .OrderBy(g => g.CreatedAt)
                    .ToList();

            return _mapper.Map<ICollection<GroupSimpleDto>>(groups);
        }

        public async Task<GroupResponseDto> GetByIdAsync(Guid groupId)
        {
            Group existingGroup = 
                await _groupRepository.SelectByIdAsync(groupId);

            if (existingGroup is null)
                throw new NotFoundException($"Group with id ({groupId}) not found.");

            return _mapper.Map<GroupResponseDto>(existingGroup);
        }

        public async Task<GroupResponseDto> UpdateAsync(
            Guid groupId,
            GroupUpdateDto dto)
        {
            Group existingGroup =
                await _groupRepository.SelectByIdAsync(groupId);

            if (existingGroup is null)
                throw new NotFoundException($"Group with id ({groupId}) not found.");

            _mapper.Map(dto, existingGroup);

            await _groupRepository.UpdateAsync();

            return _mapper.Map<GroupResponseDto>(existingGroup);
        }

        public async Task DeleteAsync(Guid groupId)
        {
            Group existingGroup =
                await _groupRepository.SelectByIdAsync(groupId);

            if (existingGroup is null)
                throw new NotFoundException($"Group with id ({groupId}) not found.");

            await _groupRepository.DeleteAsync(existingGroup);
        }
    }
}
