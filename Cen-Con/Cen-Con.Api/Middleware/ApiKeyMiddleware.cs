using Serilog;
using System.IdentityModel.Tokens.Jwt;

namespace Cen_Con.Api.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var allowedPaths = new[] {"/api/auth", "/api/auth/register" };

            if (allowedPaths.Any(p => !string.IsNullOrEmpty(p) && context.Request.Path.HasValue && context.Request.Path.StartsWithSegments(p)))
            {
                await _next(context);
                return;
            }

            var apiKeyFromConfig = _configuration["ApiSettings:ApiKey"];
            //
            Log.Information("Incoming Headers:");
            foreach (var header in context.Request.Headers)
            {
                Log.Information($"{header.Key}: {header.Value}");
            }
            if (!context.Request.Headers.TryGetValue("Authorization", out var authHeader)) {
                context.Response.StatusCode = 401;
                Log.Error("Missing authorization header");
                await context.Response.WriteAsync("Missing authorization header");
                return;
            }
            //
            var token = authHeader.ToString().Replace("Bearer ", "").Trim();

            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = 401;
                Log.Error("Missing JWT token");
                await context.Response.WriteAsync("Missing JWT token");
                return;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var apiKeyFromToken = jwtToken.Claims.FirstOrDefault(c => c.Type == "ApiKey")?.Value;

            if (apiKeyFromConfig != apiKeyFromToken)
            {
                context.Response.StatusCode = 403;
                Log.Error("Invalid Api Key");
                await context.Response.WriteAsync("Invalid Api Key");
                return;
            }

            await _next(context);
        }

    }
}
