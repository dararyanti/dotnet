using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using training.Exceptions;
using training.Models.Error;

namespace training.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next; _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                LogException(context, ex);
                await HandleExceptionAsync(context, ex);
            }
        }

        private void LogException(HttpContext context, Exception ex)
        {
            switch (ex)
            {
                case ValidationException:
                case BadRequestException:
                case ConflictException:
                case ForbiddenException:
                    _logger.LogWarning(ex, "[Client Error] {Message}", ex.Message);
                    break;

                case UnauthorizedException:
                case NotFoundException:
                case UserNotFoundException:
                    _logger.LogInformation(ex, "[Auth/Resource Error] {Path}", context.Request.Path);
                    break;

                default:
                    _logger.LogError(ex, "[Unhandled Error] {Path}", context.Request.Path);
                    break;
            }
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var status = ex switch
            {
                UserNotFoundException => HttpStatusCode.NotFound,
                NotFoundException => HttpStatusCode.NotFound,
                ValidationException => HttpStatusCode.BadRequest,
                BadRequestException => HttpStatusCode.BadRequest,
                UnauthorizedException => HttpStatusCode.Unauthorized,
                ForbiddenException => HttpStatusCode.Forbidden,
                ConflictException => HttpStatusCode.Conflict,
                _ => HttpStatusCode.InternalServerError
            };

            var error = new ErrorResponse((int)status, status.ToString(), ex.Message, context.Request.Path);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            await context.Response.WriteAsync(JsonSerializer.Serialize(error));
        }
    }
}
