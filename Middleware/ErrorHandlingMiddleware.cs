using StaffixAPI.Exceptions;
using System.Text.Json;

namespace StaffixAPI.Middleware 
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) 
        {
            this.logger = logger;
        }

        async Task IMiddleware.InvokeAsync(Microsoft.AspNetCore.Http.HttpContext context, Microsoft.AspNetCore.Http.RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(ExceptionBadRequest badRequestException)
            {
                context.Response.StatusCode = 400;
                var responseObj = new { message = badRequestException.Message };
                var jsonResponse = JsonSerializer.Serialize(responseObj);
                await context.Response.WriteAsync(jsonResponse);
            }
            catch (NotFoundException notFoundException)
            {

                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(notFoundException.Message);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong!");
            }
        }
    }
}