using LmsProjectApi.Models.UserCredentials;
using LmsProjectApi.Models.UserTokens;
using System.Threading.Tasks;

namespace LmsProjectApi.Services.Accounts
{
    public interface IAccountService
    {
        Task<UserToken> LoginAsync(UserCredential userCredential);
    }
}
