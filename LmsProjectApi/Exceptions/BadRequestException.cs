using Microsoft.AspNetCore.Http;

namespace LmsProjectApi.Exceptions
{
    public class BadRequestException(string message = "Bad request.")
        : BaseException(message, StatusCodes.Status400BadRequest, "BAD_REQUEST");
}
