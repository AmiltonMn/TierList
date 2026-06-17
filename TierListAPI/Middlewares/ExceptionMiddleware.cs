using System.Net;
using System.Text.Json;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;

namespace TierListAPI.Middlewares;

public class ExceptionMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context) 
    {
        try
        {
            await next(context);
        }
        catch (AppException ex)
        {
            await HandleExceptionAsync(context, ex.StatusCode, ex.Message);
        }
        catch (Exception) 
        {
            await HandleExceptionAsync(
                context,
                (int)HttpStatusCode.InternalServerError,
                ExceptionMessage.InternalServerError.Default
            );
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, int statusCode, string message) 
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = new
        {
            StatusCode = statusCode,
            Message = message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
           => app.UseMiddleware<ExceptionMiddleware>();
}
