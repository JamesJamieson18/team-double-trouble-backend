using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using team_double_trouble_backend.Helpers;
using team_double_trouble_backend.Services;

namespace team_double_trouble_backend.Authorization
{
    //JWT Middleware extracts the token from a request and validates it, if validation fails the user will only be able to access routes with the AllowAnonymous attribute and will not be attached to the HTTP context, AuthUsers will handle failed authorizations and return a 401 Unauthorized response.
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Settings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<Settings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetById(userId.Value);
            }

            await _next(context);
        }
    }
}