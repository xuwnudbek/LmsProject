using AutoMapper;
using FluentValidation;
using LmsProjectApi.DTOs.Attendances;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models.Attendances;
using LmsProjectApi.Repositories.Attendances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Attendances
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IValidator<AttendanceCreateDto> _attendanceCreateValidator;
        private readonly IValidator<AttendanceUpdateDto> _attendanceUpdateValidator;
        private readonly IMapper _mapper;

        public AttendanceService(
            IAttendanceRepository attendanceRepository,
            IValidator<AttendanceCreateDto> attendanceCreateValidator,
            IValidator<AttendanceUpdateDto> attendanceUpdateValidator,
            IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
            _attendanceCreateValidator = attendanceCreateValidator;
            _attendanceUpdateValidator = attendanceUpdateValidator;
        }

        public async Task<AttendanceResponseDto> AddAsync(AttendanceCreateDto dto)
        {
            var validatorResult = _attendanceCreateValidator.Validate(dto);

            if (!validatorResult.IsValid)
                throw new Exceptions.ValidationException(validatorResult.Errors);

            Attendance attendance = _mapper.Map<Attendance>(dto);

            Attendance inserted =
                await _attendanceRepository.InsertAsync(attendance);

            return _mapper.Map<AttendanceResponseDto>(inserted);
        }

        public ICollection<AttendanceResponseDto> GetAll()
        {
            ICollection<Attendance> attendances =
                _attendanceRepository.SelectAll().ToList();

            return _mapper.Map<ICollection<AttendanceResponseDto>>(attendances);
        }

        public async Task<AttendanceResponseDto> GetByIdAsync(Guid attendanceId)
        {
            Attendance existingAttendance =
                await _attendanceRepository.SelectByIdAsync(attendanceId);

            if (existingAttendance is null)
                throw new NotFoundException($"Attendance with id ({attendanceId}) not found.");

            return _mapper.Map<AttendanceResponseDto>(existingAttendance);
        }

        public async Task<AttendanceResponseDto> UpdateAsync(
            Guid attendanceId,
            AttendanceUpdateDto dto)
        {
            var validatorResult = _attendanceUpdateValidator.Validate(dto);

            if (!validatorResult.IsValid)
                throw new Exceptions.ValidationException(validatorResult.Errors);

            Attendance existingAttendance =
                await _attendanceRepository.SelectByIdAsync(attendanceId);

            if (existingAttendance is null)
                throw new NotFoundException($"Attendance with id ({attendanceId}) not found.");

            _mapper.Map(dto, existingAttendance);

            await _attendanceRepository.UpdateAsync();

            return _mapper.Map<AttendanceResponseDto>(existingAttendance);
        }

        public async Task DeleteAsync(Guid attendanceId)
        {
            Attendance existingAttendance =
                await _attendanceRepository.SelectByIdAsync(attendanceId);

            if (existingAttendance is null)
                throw new NotFoundException($"Attendance with id ({attendanceId}) not found.");

            await _attendanceRepository.DeleteAsync(existingAttendance);
        }
    }
}
