using LmsProjectApi.Data.Context;
using LmsProjectApi.Models.Courses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _dbContext;

        public CourseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Course> InsertAsync(Course course)
        {
            var entry = await _dbContext.Courses.AddAsync(course);
            await _dbContext.SaveChangesAsync();

            return await SelectByIdAsync(entry.Entity.Id);
        }

        public IQueryable<Course> SelectAll()
        {
            return _dbContext.Courses
                .AsNoTracking();
        }

        public Task<Course> SelectByIdAsync(Guid courseId)
        {
            return _dbContext.Courses
                .Include(c => c.User)
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(c => c.Id == courseId);
        }

        public async Task UpdateAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Course course)
        {
            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();
        }
    }
}
