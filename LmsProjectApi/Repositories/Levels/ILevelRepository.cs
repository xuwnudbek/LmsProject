using LmsProjectApi.Models.Levels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Levels
{
    public interface ILevelRepository
    {
        Task<Level> InsertAsync(Level level);
        IQueryable<Level> SelectAll();
        Task<Level> SelectByIdAsync(Guid id);
        Task UpdateAsync();
        Task DeleteAsync(Level level);
    }
}
