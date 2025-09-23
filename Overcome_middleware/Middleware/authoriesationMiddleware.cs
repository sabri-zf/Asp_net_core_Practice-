
namespace Overcome_middleware.Middleware
{
    public class authoriesationMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string id = context.Request.Query["id"].ToString();

            if (!string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Valid Data ..... !");

                await context.Response.WriteAsync("\n\nWelcome Mr King " + id);   
            }

           await next(context);
        }
    }
}
