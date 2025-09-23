namespace Overcome_middleware.Middleware
{


    // build middleware class another way to create middleware request pipeline 
    public class AnotherCustomeMiddleware
    {
        // inject it by Asp.net Core via Dependency injection pattren
        private readonly RequestDelegate _next;

        public AnotherCustomeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("My name Another middleware class i'm in the Top");
            await _next(context);
            await context.Response.WriteAsync("My name Another middleware class i'm in the bottom");
        }
    }


    public static class AnothercustomeMiddlewareExtension
    {
        public static IApplicationBuilder UseAnotherMiddleware (this IApplicationBuilder app)
        {
            return app.UseMiddleware<AnotherCustomeMiddleware>();
        }
    }
}
