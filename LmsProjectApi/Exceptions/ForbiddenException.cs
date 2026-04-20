using Microsoft.AspNetCore.Http;

namespace LmsProjectApi.Exceptions
{
    public class ForbiddenException(string message = "Access forbidden.")
        : BaseException(message, StatusCodes.Status403Forbidden, "FORBIDDEN");
}