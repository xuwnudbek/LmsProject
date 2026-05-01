using LmsProjectApi.Models.Courses;
using LmsProjectApi.Models.Lessons;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Lessons
{
    public interface ILessonRepository
    {
        Task<Lesson> InsertAsync(Lesson lesson);
        IQueryable<Lesson> SelectAll();
        Task<Lesson> SelectByIdAsync(Guid lessonId);
        Task UpdateAsync();
        Task DeleteAsync(Lesson lesson);
    }
}
