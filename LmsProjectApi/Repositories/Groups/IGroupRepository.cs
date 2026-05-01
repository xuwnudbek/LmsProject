using LmsProjectApi.Models.Groups;
using LmsProjectApi.Models.Lessons;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.Groups
{
    public interface IGroupRepository
    {
        Task<Group> InsertAsync(Group group);
        IQueryable<Group> SelectAll();
        Task<Group> SelectByIdAsync(Guid groupId);
        Task UpdateAsync();
        Task DeleteAsync(Group group);
    }
}
