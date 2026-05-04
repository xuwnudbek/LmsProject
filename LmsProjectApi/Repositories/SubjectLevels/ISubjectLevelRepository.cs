using LmsProjectApi.Models.SubjectLevels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LmsProjectApi.Repositories.SubjectLevels
{
    public interface ISubjectLevelRepository
    {
        Task DeleteAsync(SubjectLevel subjectLevel);
        Task DeleteRangeAsync(ICollection<SubjectLevel> subjectLevels);
    }
}
