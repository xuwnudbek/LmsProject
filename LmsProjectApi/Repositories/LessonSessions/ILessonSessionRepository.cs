using LmsProjectApi.Models.LessonSessions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.LessonSessions
{
    public interface ILessonSessionRepository
    {
        Task<LessonSession> InsertAsync(LessonSession lessonSession);
        IQueryable<LessonSession> SelectAll();
        Task<LessonSession> SelectByIdAsync(Guid lessonSessionId);
        Task UpdateAsync();
        Task DeleteAsync(LessonSession lessonSession);
    }
}
