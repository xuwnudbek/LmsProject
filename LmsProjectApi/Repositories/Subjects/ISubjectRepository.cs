using LmsProjectApi.Models.Subjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Subjects
{
    public interface ISubjectRepository
    {
        Task<Subject> InsertAsync(Subject subject);
        IQueryable<Subject> SelectAllAsync();
        Task<Subject> SelectByIdAsync(Guid id);
        Task UpdateAsync();
        Task DeleteAsync(Subject subject);
    }
}