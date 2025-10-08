
namespace Overcome_middleware.Middleware.Extensions
{


    // create extension class to manage the middleware reques pipeline
    public static class MycutomeMiddlewareExtension
    {
        public static IApplicationBuilder SendMessageMiddleware(this IApplicationBuilder app)
        {
            // call the Invoke method via class MycustomeMiddleware
            app.UseMiddleware<MyCustomeMiddleware>();
            return app;
        }
    }
}
