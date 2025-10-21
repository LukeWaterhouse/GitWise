using GitWise.Api.Models.Errors;

namespace GitWise.Api.Middleware;

public class ExceptionMiddleware() : IMiddleware
{
    private const string UnhandledExceptionTitle = "An unhandled exception occurred.";
    
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {

        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            //TODO: log exception with some kind of trace id, keeping the variable to avoid compiler warning
            var _ = ex;
            await WriteSingleErrorResponseAsync(context, StatusCodes.Status500InternalServerError, UnhandledExceptionTitle);
        }
    }
    
    private async Task WriteSingleErrorResponseAsync(HttpContext context, int status, string message)
    {
        context.Response.StatusCode = status;
        await context.Response.WriteAsJsonAsync(
            new ErrorsDto(
                new List<ErrorDto>
                {
                    new(status, message)
                }));
    }
}
