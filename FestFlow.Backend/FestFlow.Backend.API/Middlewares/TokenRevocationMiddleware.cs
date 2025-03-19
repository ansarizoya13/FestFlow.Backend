using FestFlow.Backend.API.Controllers;

namespace FestFlow.Backend.API.Middlewares
{
    public class TokenRevocationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenRevocationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (AuthController._revokedTokens.Contains(token))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Token has been revoked. Please log in again.");
                return;
            }

            await _next(context);
        }
    }
}
