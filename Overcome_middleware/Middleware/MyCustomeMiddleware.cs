
namespace Overcome_middleware.Middleware
{

    // create class MycutomeMiddleware to manage the procees of middleware
    public class MyCustomeMiddleware : IMiddleware
    {

        // implement interface to build behavior of middleware pipeline 
        // via InvokeAsync method
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // before invoke next middleware block of code 
            await context.Response.WriteAsync("\n\nHI welcome to my middleware customesation");
            await next(context);
           // after invoke next middleware  block of code 
        }
    }
}

