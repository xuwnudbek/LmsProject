using LmsProjectApi.Models.Courses;
using LmsProjectApi.Models.Levels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Courses
{
    public interface ICourseRepository
    {
        Task<Course> InsertAsync(Course course);
        IQueryable<Course> SelectAll();
        Task<Course> SelectByIdAsync(Guid courseId);
        Task UpdateAsync();
        Task DeleteAsync(Course course);
    }
}
