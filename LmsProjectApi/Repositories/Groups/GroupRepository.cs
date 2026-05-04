using LmsProjectApi.Data.Context;
using LmsProjectApi.Models.Groups;
using LmsProjectApi.Models.Lessons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Groups
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _dbContext;

        public GroupRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Group> InsertAsync(Group group)
        {
            var entry = await _dbContext.Groups.AddAsync(group);
            await _dbContext.SaveChangesAsync();

            return await SelectByIdAsync(entry.Entity.Id);
        }

        public IQueryable<Group> SelectAll()
        {
            return _dbContext.Groups
                .AsNoTracking();
        }

        public Task<Group> SelectByIdAsync(Guid groupId)
        {
            return _dbContext.Groups
                .Include(g => g.Level)
                .Include(g => g.Course)
                    .ThenInclude(c => c.Subject)
                .Include(g => g.Course)
                    .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(g => g.Id == groupId);
        }

        public async Task UpdateAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Group group)
        {
            _dbContext.Groups.Remove(group);
            await _dbContext.SaveChangesAsync();
        }
    }
}
