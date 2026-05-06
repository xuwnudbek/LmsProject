using LmsProjectApi.Models.Api;
using LmsProjectApi.Models.UserCredentials;
using LmsProjectApi.Models.UserTokens;
using LmsProjectApi.Services.Accounts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LmsProjectApi.Controllers
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("api/login")]
        public async Task<ActionResult<UserToken>> LoginAsync(UserCredential credential)
        {
            UserToken userToken =
                await _accountService.LoginAsync(credential);

            return Ok(ApiResponse<UserToken>.Ok(userToken, "Successfully logged in."));
        }
    }
}
