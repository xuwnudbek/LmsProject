using LmsProjectApi.Data.Context;
using LmsProjectApi.Models.Attendances;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Attendances
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _dbContext;

        public AttendanceRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Attendance> InsertAsync(Attendance attendance)
        {
            var entry = await _dbContext.Attendances.AddAsync(attendance);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public IQueryable<Attendance> SelectAll()
        {
            return _dbContext.Attendances
                .AsNoTracking();
        }

        public Task<Attendance> SelectByIdAsync(Guid attendanceId)
        {
            return _dbContext.Attendances.
                FirstOrDefaultAsync(l => l.Id == attendanceId);
        }

        public async Task UpdateAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Attendance attendance)
        {
            _dbContext.Attendances.Remove(attendance);
            await _dbContext.SaveChangesAsync();
        }
    }
}
