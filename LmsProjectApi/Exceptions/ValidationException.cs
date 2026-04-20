using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace LmsProjectApi.Exceptions
{
    public class ValidationException : BaseException
    {
        public Dictionary<string, string[]> Errors { get; }

        public ValidationException(Dictionary<string, string[]> errors)
            : base("One or more validation error occured.", StatusCodes.Status422UnprocessableEntity, "VALIDATION_ERROR")
        {
            Errors = errors;
        }

        public ValidationException(string propertyName, string errorMessage)
            : base("Validation error occurred.", StatusCodes.Status422UnprocessableEntity, "VALIDATION_ERROR")
        {
            Errors = new Dictionary<string, string[]>
            {
                { propertyName, [errorMessage] }
            };
        }

    }
}
