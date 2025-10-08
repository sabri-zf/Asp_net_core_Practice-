
/*  
    we known now what happen when create wbeApplicationBuilder 
    then create instance from wbeApplication templet by wbeApplicationBuilder.bulid
*/

using Overcome_middleware.Middleware;
using Overcome_middleware.Middleware.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Create server container wholw serveres 
builder.Services.AddTransient<MyCustomeMiddleware>();
builder.Services.AddTransient<authoriesationMiddleware>();
var app = builder.Build();

// middleware collection of component calling when WebApplication has been builded 
// the mean concepte of middleware is calling next middleware by Next() func dealeget
// Run method it's can generate middleware using it but can use it to call next method
// called => short-ciruct middleware 

//app.Run(async (HttpContext context)=>
//{
//    await context.Response.WriteAsync("Hi there, this is my first respnse :)");
//});

//// the seconde response could appear on Browser render
//app.Run(async (HttpContext context) =>
//{
//    await context.Response.WriteAsync("Hi there, this is my seconde respnse :)");
//});

//===================================================
// on the other hand when using ,'Use method' you can call the next middleware
// called => terminal middleware

// Middleware 1
app.Use(async (HttpContext _context, RequestDelegate _next) =>
    {

        await _context.Response.WriteAsync("Hi there, I'm using the Use Method to call next middleware :)");
       // it'll calling next middleware by Httpcontext
        await _next(_context);

       // you can hit any logic code
    });


// create custome middleware 
// Middleware 2
app.UseMiddleware<MyCustomeMiddleware>();

// create second custome middleware
// Middleware 3
app.UseMiddleware<authoriesationMiddleware>();

//use extension extension class to invoke Asynchronous request pipelien
// Middleware 4
app.SendMessageMiddleware();

// user another way to invoke middleware
// Middleware 5
app.UseAnotherMiddleware();

// conditionally middleware using UseWhen method
// Middleware 6
app.UseWhen((context) => context.Request.Query["authorized"] == "true",
    config =>
    {
        config.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("\n\n The is authorized");
            await next(context);
        });
    });


// short-circuit request pipeline middleware
// Middleware 7
app.Run(async (HttpContext _context) =>
{
    await _context.Response.WriteAsync("Hi there, I'm the next middleware thank you to called me:)");  
    // you can hit any logic code 
});



app.Run();
