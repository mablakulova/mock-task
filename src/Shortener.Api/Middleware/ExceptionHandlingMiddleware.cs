using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Shortener.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate requestDelegate;
    private readonly ILogger<ExceptionHandlingMiddleware> logger;

    public ExceptionHandlingMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlingMiddleware> logger)
    {
        this.requestDelegate = requestDelegate;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await requestDelegate(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        logger.LogError(exception.ToString());

        var errorMessage = new { Message = exception.Message, Code = "system_error" };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorMessage));
    }
}
