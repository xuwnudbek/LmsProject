using LmsProjectApi.Data.Context;
using LmsProjectApi.Models.Lessons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Lessons
{
    public class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _dbContext;

        public LessonRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Lesson> InsertAsync(Lesson lesson)
        {
            var entry = await _dbContext.Lessons.AddAsync(lesson);
            await _dbContext.SaveChangesAsync();

            return entry.Entity;
        }

        public IQueryable<Lesson> SelectAll()
        {
            return _dbContext.Lessons
                .AsNoTracking();
        }

        public Task<Lesson> SelectByIdAsync(Guid lessonId)
        {
            return _dbContext.Lessons.
                FirstOrDefaultAsync(l => l.Id == lessonId);
        }

        public async Task UpdateAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Lesson lesson)
        {
            _dbContext.Lessons.Remove(lesson);
            await _dbContext.SaveChangesAsync();
        }
    }
}
