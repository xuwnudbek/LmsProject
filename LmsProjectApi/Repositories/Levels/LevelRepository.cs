using LmsProjectApi.Data;
using LmsProjectApi.Models.Levels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Levels
{
    public class LevelRepository : ILevelRepository
    {
        private readonly AppDbContext _dbContext;

        public LevelRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Level> InsertAsync(Level level)
        {
            _dbContext.Levels.Add(level);
            await _dbContext.SaveChangesAsync();

            return level;
        }

        public IQueryable<Level> SelectAll()
        {
            return _dbContext.Levels
                .AsNoTracking();
        }

        public Task<Level> SelectByIdAsync(Guid id)
        {
            return _dbContext.Levels
                .FirstOrDefaultAsync(level=> level.Id == id);
        }

        public Task UpdateAsync() =>
            _dbContext.SaveChangesAsync();

        public Task DeleteAsync(Level level)
        {
            _dbContext.Levels.Remove(level);
            return _dbContext.SaveChangesAsync();
        }
    }
}
