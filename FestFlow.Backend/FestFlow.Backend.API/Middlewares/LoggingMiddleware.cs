using System.Net;
using Microsoft.Data.SqlClient;

namespace FestFlow.Backend.API.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var request = httpContext.Request;
            var response = httpContext.Response;

            try
            {
                LogRequestInfo(request, httpContext);
                await _next(httpContext);
                LogResponseInfo(response);
            }
            catch (Exception ex)
            {
                await HandleError(httpContext, ex);
            }
        }

        #region Helper methods
        private void LogRequestInfo(HttpRequest request, HttpContext httpContext)
        {
            _logger.LogInformation("\n-------------------- Incoming Request --------------------");
            _logger.LogInformation($"> Method:- {request.Method}");
            _logger.LogInformation($"> Path:- {request.Path}");
            _logger.LogInformation($"> QueryString:- {request.QueryString}");
            //_logger.LogInformation($"> Headers : {string.Join(";", request.Headers.Select(h => $"{h.Key}: {h.Value}"))}");
            _logger.LogInformation($"> IP Address:- {httpContext.Connection.RemoteIpAddress?.ToString()}");
        }

        private void LogResponseInfo(HttpResponse response)
        {
            _logger.LogInformation("\n-------------------- Outgoing Response --------------------");
            _logger.LogInformation("> StatusCode:- {StatusCode}\n", response.StatusCode);
        }

        private (HttpStatusCode, string) GetErrorDetails(Exception ex)
        {
            switch (ex)
            {
                case InvalidOperationException _:
                    return (HttpStatusCode.BadRequest, "Database update error occurred during query execution.");
                case SqlException _:
                    return (HttpStatusCode.InternalServerError, "SQL exception occurred during query execution.");
                case UnauthorizedAccessException _:
                    return (HttpStatusCode.Unauthorized, "Unauthorized access error occurred.");
                default:
                    return (HttpStatusCode.InternalServerError, "An unexpected error occurred. Please try again later.");
            }
        }

        private async Task HandleError(HttpContext httpContext, Exception ex)
        {
            var request = httpContext.Request;
            var response = httpContext.Response;

            (HttpStatusCode statusCode, string message) = GetErrorDetails(ex);

            _logger.LogError("\n-------------------- Error log --------------------");
            _logger.LogError($"> Method:- {request.Method}");
            _logger.LogError($"> Path:- {request.Path}");
            _logger.LogError($"> QueryString:- {request.QueryString}");
            _logger.LogError($"> Status code:- {(int)statusCode}");
            _logger.LogError($"> Error Message: {ex.Message}");
            _logger.LogError($"> Inner Exception: {ex.InnerException}");
            _logger.LogError($"> Stack Trace: {ex.StackTrace}");

            response.StatusCode = (int)statusCode;
            await httpContext.Response.WriteAsync(message);
        }
        #endregion
    }
}
