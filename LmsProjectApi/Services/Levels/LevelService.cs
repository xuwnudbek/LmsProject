using AutoMapper;
using FluentValidation;
using LmsProjectApi.DTOs.Levels;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models.Levels;
using LmsProjectApi.Repositories.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Levels
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _levelRepository;
        private readonly IValidator<LevelUpdateDto> _levelUpdateValidator;
        private readonly IMapper _mapper;

        public LevelService(
            ILevelRepository levelRepository,
            IMapper mapper,
            IValidator<LevelUpdateDto> levelUpdateValidator)
        {
            _levelRepository = levelRepository;
            _mapper = mapper;
            _levelUpdateValidator = levelUpdateValidator;
        }

        public async Task<LevelResponseDto> AddAsync(LevelCreateDto dto)
        {
            Level level = _mapper.Map<Level>(dto);

            Level newLevel =
                await _levelRepository.InsertAsync(level);

            return _mapper.Map<LevelResponseDto>(newLevel);
        }

        public ICollection<LevelResponseDto> GetAll()
        {
            ICollection<Level> levels = 
                _levelRepository
                    .SelectAll()
                    .OrderBy(l => l.CreatedAt)
                    .ToList();

            return _mapper.Map<ICollection<LevelResponseDto>>(levels);
        }

        public async Task<LevelResponseDto> GetByIdAsync(Guid levelId)
        {
            Level existingLevel =
                await _levelRepository.SelectByIdAsync(levelId);

            if (existingLevel is null)
                throw new NotFoundException($"Level with id ({levelId}) not found");

            return _mapper.Map<LevelResponseDto>(existingLevel);
        }

        public async Task<LevelResponseDto> UpdateAsync(
            Guid levelId,
            LevelUpdateDto dto)
        {
            var result = _levelUpdateValidator.Validate(dto);

            if (!result.IsValid)
                throw new Exceptions.ValidationException(result.Errors);

            Level existingLevel =
                await _levelRepository.SelectByIdAsync(levelId);

            if (existingLevel is null)
                throw new NotFoundException($"Level with id ({levelId}) not found");
            
            existingLevel.Name = dto.Name;

            await _levelRepository.UpdateAsync();

            return _mapper.Map<LevelResponseDto>(existingLevel);
        }

        public async Task DeleteAsync(Guid levelId)
        {
            Level existingLevel =
                await _levelRepository.SelectByIdAsync(levelId);

            if (existingLevel is null)
                throw new NotFoundException($"Level with id ({levelId}) not found.");

            await _levelRepository.DeleteAsync(existingLevel);
        }
    }
}
