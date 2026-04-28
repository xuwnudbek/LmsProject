using LmsProjectApi.Data;
using LmsProjectApi.Models.Subjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Subjects
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _dbContext;

        public SubjectRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Subject> InsertAsync(Subject subject)
        {
            _dbContext.Subjects.Add(subject);
            await _dbContext.SaveChangesAsync();

            return subject;
        }

        public IQueryable<Subject> SelectAllAsync() =>
            _dbContext.Subjects
                .AsNoTracking();

        public Task<Subject> SelectByIdAsync(Guid subjectId) =>
            _dbContext.Subjects
                .Include(s => s.SubjectLevels)
                    .ThenInclude(sl => sl.Level)
                .FirstOrDefaultAsync(s => s.Id == subjectId);

        public Task UpdateAsync() =>
            _dbContext.SaveChangesAsync();

        public Task DeleteAsync(Subject subject)
        {
            _dbContext.Subjects.Remove(subject);
            return _dbContext.SaveChangesAsync();
        }
    }
}