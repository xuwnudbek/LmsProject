using Microsoft.AspNetCore.Http;

namespace LmsProjectApi.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message)
            : base(message, StatusCodes.Status404NotFound, "NOT_FOUND")
        { }
    }
}
