using LmsProjectApi.Data.Context;
using LmsProjectApi.Models.LessonSessions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.LessonSessions
{
    public class LessonSessionRepository : ILessonSessionRepository
    {
        private readonly AppDbContext _dbContext;

        public LessonSessionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LessonSession> InsertAsync(LessonSession lessonSession)
        {
            var entry = await _dbContext.LessonSessions.AddAsync(lessonSession);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public IQueryable<LessonSession> SelectAll()
        {
            return _dbContext.LessonSessions
                .AsNoTracking();
        }

        public Task<LessonSession> SelectByIdAsync(Guid lessonSessionId)
        {
            return _dbContext.LessonSessions.
                FirstOrDefaultAsync(l => l.Id == lessonSessionId);
        }

        public async Task UpdateAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(LessonSession lessonSession)
        {
            _dbContext.LessonSessions.Remove(lessonSession);
            await _dbContext.SaveChangesAsync();
        }
    }
}
