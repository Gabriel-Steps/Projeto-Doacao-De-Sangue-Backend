using ProjetoDoacaoDeSangue.Application.Exceptions;
using ProjetoDoacaoDeSangue.Core.Models;

namespace ProjetoDoacaoDeSangue.Application.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                await HandleApplicationException(context, ex);
            }
            catch (Exception)
            {
                await HandleUnknownException(context);
            }
        }

        private static async Task HandleApplicationException(
            HttpContext context,
            ApiException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            context.Response.ContentType = "application/json";

            var response = new ApiResponse<object>
            {
                Status = false,
                Message = ex.Message,
                Value = null
            };

            await context.Response.WriteAsJsonAsync(response);
        }

        private static async Task HandleUnknownException(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsJsonAsync(new ApiResponse<object>
            {
                Status = false,
                Message = "An unexpected error occurred.",
                Value = null
            });
        }
    }
}
