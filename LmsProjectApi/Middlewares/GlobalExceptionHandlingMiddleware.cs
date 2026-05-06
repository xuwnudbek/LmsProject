using System;
using System.Threading.Tasks;
using LmsProjectApi.Exceptions;
using LmsProjectApi.Models.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace LmsProjectApi.Middlewares;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);

            var statusCode = exception switch
            {
                ConflictException => StatusCodes.Status409Conflict,
                ForbiddenException => StatusCodes.Status403Forbidden,
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                ValidationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            dynamic errorMessage;

            if (exception is ValidationException exc)
            {
                errorMessage = exc.Errors;
            }
            else
            {
                errorMessage = exception switch
                {
                    ConflictException => exception.Message,
                    ForbiddenException => exception.Message,
                    NotFoundException => exception.Message,
                    UnauthorizedException => exception.Message,
                    _ => exception.InnerException is null
                    ? exception.Message
                    : exception.InnerException.Message
                };
            }

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(
                ApiResponse<ErrorResponse>.Fail(new ErrorResponse
                {
                    StatusCode = statusCode,
                    ErrorMessage = errorMessage
                })
            );
        }
    }
}

