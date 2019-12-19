using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Network_Analyzer_Backend.Extensions;
using System;
using System.Threading.Tasks;

namespace Network_Analyzer_Backend.Middleware
{
    /// <summary>
    ///     Middleware for treatment exceptions
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.TreatmentException(exception, out int statusCode, out string message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            return context.Response.WriteAsync(message);
        }
    }
}
