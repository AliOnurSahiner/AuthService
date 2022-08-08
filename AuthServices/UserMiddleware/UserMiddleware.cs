using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Threading.Tasks;

namespace AuthServices.UserMiddleware
{

    public class UserMiddleware
    {
        private readonly RequestDelegate _next;
        public UserMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                Log.Information("Custom middleware");
                await _next(httpContext);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseUserMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<UserMiddleware>();
        }

    }
}
