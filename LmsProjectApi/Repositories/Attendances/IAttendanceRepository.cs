using LmsProjectApi.Models.Attendances;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Attendances
{
    public interface IAttendanceRepository
    {
        Task<Attendance> InsertAsync(Attendance attendance);
        IQueryable<Attendance> SelectAll();
        Task<Attendance> SelectByIdAsync(Guid attendanceId);
        Task UpdateAsync();
        Task DeleteAsync(Attendance attendance);
    }
}
