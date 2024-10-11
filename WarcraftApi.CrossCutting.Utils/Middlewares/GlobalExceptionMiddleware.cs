using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using WarcraftApi.CrossCutting.Utils.Logger;

namespace WarcraftApi.CrossCutting.Utils.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILoggerService? _logger;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
        _logger = LoggerProvider.GetLogger();
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        _logger?.LogError($"Unhandled exception: {ex.Message}", ex);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "An error occurred while processing your request.",
            Detailed = ex.Message
        };

        var jsonResponse = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(jsonResponse);
    }
}