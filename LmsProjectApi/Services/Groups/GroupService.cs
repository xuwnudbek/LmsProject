using AutoMapper;
using FluentValidation;
using LmsProjectApi.DTOs.Groups;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models.Groups;
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
        private readonly IValidator<GroupCreateDto> _groupCreateValidator;
        private readonly IValidator<GroupUpdateDto> _groupUpdateValidator;
        private readonly IMapper _mapper;

        public GroupService(
            IGroupRepository groupRepository,
            IValidator<GroupCreateDto> groupCreateValidator,
            IValidator<GroupUpdateDto> groupUpdateValidator,
            IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
            _groupCreateValidator = groupCreateValidator;
            _groupUpdateValidator = groupUpdateValidator;
        }

        public async Task<GroupResponseDto> AddAsync(GroupCreateDto dto)
        {
            var validatorResult = _groupCreateValidator.Validate(dto);

            if (!validatorResult.IsValid)
                throw new Exceptions.ValidationException(validatorResult.Errors);

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
            var validatorResult = _groupUpdateValidator.Validate(dto);

            if (!validatorResult.IsValid)
                throw new Exceptions.ValidationException(validatorResult.Errors);

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
