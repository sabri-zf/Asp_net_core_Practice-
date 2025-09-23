
namespace Overcome_middleware.Middleware
{
    public class MyCustomeMiddleware : IMiddleware
    {

        public int x { get; set; }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // before invoke next middleware block of code 

            await context.Response.WriteAsync("\n\nHI welcome to my middleware customesation");
            await next(context);
           // after invoke next middleware  block of code 
        }
    }
}
