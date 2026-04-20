using Microsoft.AspNetCore.Http;

namespace LmsProjectApi.Exceptions
{
    public class UnauthorizedException(string message = "Unauthorized access.")
        : BaseException(message, StatusCodes.Status401Unauthorized, "UNAUTHORIZED");
}