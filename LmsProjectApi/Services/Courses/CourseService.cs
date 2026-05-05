using AutoMapper;
using FluentValidation;
using LmsProjectApi.DTOs.Courses;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models.Courses;
using LmsProjectApi.Models.UserCredentials;
using LmsProjectApi.Repositories.Courses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Courses
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IValidator<CourseCreateDto> _courseCreateValidator;
        private readonly IValidator<CourseUpdateDto> _courseUpdateValidator;
        private readonly IMapper _mapper;

        public CourseService(
            ICourseRepository courseRepository,
            IValidator<CourseCreateDto> courseCreateValidator,
            IValidator<CourseUpdateDto> courseUpdateValidator,
            IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _courseCreateValidator = courseCreateValidator;
            _courseUpdateValidator = courseUpdateValidator;
        }

        public async Task<CourseResponseDto> AddAsync(CourseCreateDto dto)
        {
            var validationResult = _courseCreateValidator.Validate(dto);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult.Errors);

            Course course = _mapper.Map<Course>(dto);

            Course created = 
                await _courseRepository.InsertAsync(course);

            return _mapper.Map<CourseResponseDto>(created);
        }


        public ICollection<CourseResponseDto> GetAll()
        {
            ICollection<Course> courses = 
                _courseRepository
                    .SelectAll()
                    .Include(c => c.User)
                    .Include(c => c.Subject)
                    .ToList();

            return _mapper.Map<ICollection<CourseResponseDto>>(courses);
        }

        public async Task<CourseResponseDto> GetByIdAsync(Guid courseId)
        {
            Course course =
                await _courseRepository.SelectByIdAsync(courseId);

            return _mapper.Map<CourseResponseDto>(course);
        }

        public async Task<CourseResponseDto> UpdateAsync(
            Guid courseId,
            CourseUpdateDto dto)
        {
            var validationResult = _courseUpdateValidator.Validate(dto);

            if (!validationResult.IsValid)
                throw new Exceptions.ValidationException(validationResult.Errors);

            Course existingCourse =
                await _courseRepository.SelectByIdAsync(courseId);

            if (existingCourse is null)
                throw new NotFoundException($"Course with id ({courseId}) not found.");

            _mapper.Map(dto, existingCourse);

            await _courseRepository.UpdateAsync();

            return _mapper.Map<CourseResponseDto>(existingCourse);
        }
        
        public async Task DeleteAsync(Guid courseId)
        {
            Course existingCourse =
                await _courseRepository.SelectByIdAsync(courseId);

            if (existingCourse is null)
                throw new NotFoundException($"Course with id ({courseId}) not found.");

            await _courseRepository.DeleteAsync(existingCourse);
        }

    }
}
