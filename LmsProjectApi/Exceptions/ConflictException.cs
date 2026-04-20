using Microsoft.AspNetCore.Http;

namespace LmsProjectApi.Exceptions
{
    public class ConflictException(string message) 
        : BaseException(message, StatusCodes.Status409Conflict, "CONFLICT");
}
