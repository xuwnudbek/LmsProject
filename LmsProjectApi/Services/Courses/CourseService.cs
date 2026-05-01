using AutoMapper;
using LmsProjectApi.DTOs.Courses;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models.Courses;
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
        private readonly IMapper _mapper;

        public CourseService(
            ICourseRepository courseRepository,
            IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseResponseDto> AddAsync(CourseCreateDto dto)
        {
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
            Course existingCourse =
                await _courseRepository.SelectByIdAsync(courseId);

            if (existingCourse is null)
                throw new NotFoundException($"Course with id ({courseId}) not found.");

            _mapper.Map(dto, existingCourse);

            //existingCourse.Name = dto.Name;
            //existingCourse.Description = dto.Description;
            //existingCourse.PaymentValue = dto.PaymentValue;
            //existingCourse.DurationInDays = dto.DurationInDays;
            //existingCourse.SubjectId = dto.SubjectId;
            //existingCourse.UserId = dto.UserId;
            //existingCourse.LevelId = dto.LevelId;

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
