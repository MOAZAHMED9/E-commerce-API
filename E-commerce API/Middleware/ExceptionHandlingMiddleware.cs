using E_commerce_API.Exception;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_commerce_API.Middleware
{
    public class ExceptionHandlingMiddleware              /////////////////////////
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)        //بيناديها مع كل HTTP request.
        {
            try
            {
                await _next(context);
            }

            catch(NotFoundException ex)
            {
                _logger.LogError(ex, "Not Found error occurred");
                await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
            }
            catch(UnauthorizedAccessException ex)
            {
                _logger.LogError(ex, "Unauthorized access error occurred");
                await HandleExceptionAsync(context, HttpStatusCode.Unauthorized, ex.Message);
            }
            catch(ForbiddenAccessException ex)
            {
                _logger.LogError(ex, "Forbidden access error occurred");
                await HandleExceptionAsync(context, HttpStatusCode.Forbidden, ex.Message);
            }

            catch (BadRequestException ex)
            {
                _logger.LogError(ex, "Bad Request error occurred");
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
            }

            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogWarning(ex, "Concurrency conflict occurred.");

                await HandleExceptionAsync(context, HttpStatusCode.Conflict, "The data was modified by another request. Please try again.");
            }

            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error occurred");

                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, "An error occurred while updating the database.");
            }

            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred");

                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "An unexpected error occurred.");
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsJsonAsync(new
            {
                statusCode = (int)statusCode,
                message = message
            });
        }

    }
}
