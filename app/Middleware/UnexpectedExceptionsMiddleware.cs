namespace API.Middleware;

public class UnexpectedExceptionsMiddleware(
    RequestDelegate next,
    ILogger<UnexpectedExceptionsMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "An unhandled exception occurred while processing request: {RequestPath}",
                context.Request.Path
            );

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "text/plain";

            await context.Response.WriteAsync("Internal Server Error\n");
        }
    }
}

public static class UnexpectedExceptionsMiddlewareExtensions
{
    public static IApplicationBuilder UseUnexpectedExceptions(this IApplicationBuilder app)
    {
        return app.UseMiddleware<UnexpectedExceptionsMiddleware>();
    }
}
