
namespace Overcome_middleware.Middleware.Extensions
{

    public static class MycutomeMiddlewareExtension
    {
        public static IApplicationBuilder SendMessageMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<MyCustomeMiddleware>();
            return app;
        }
    }
}
