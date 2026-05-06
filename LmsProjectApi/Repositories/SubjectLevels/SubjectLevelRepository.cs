using LmsProjectApi.Data.Context;
using LmsProjectApi.Models.SubjectLevels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.SubjectLevels
{
    public class SubjectLevelRepository : ISubjectLevelRepository
    {
        private readonly AppDbContext _dbContext;

        public SubjectLevelRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(SubjectLevel subjectLevel)
        {
            _dbContext.SubjectLevels.Remove(subjectLevel);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(ICollection<SubjectLevel> subjectLevels)
        {
            _dbContext.SubjectLevels.RemoveRange(subjectLevels);
            await _dbContext.SaveChangesAsync();
        }


    }
}
