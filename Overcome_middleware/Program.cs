
/*  
    we known now what happen when create wbeApplicationBuilder 
    then create instance from wbeApplication templet by wbeApplicationBuilder.bulid
*/

var builder = WebApplication.CreateBuilder(args);
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

app.Use(async (HttpContext _context, RequestDelegate _next) =>
    {

        await _context.Response.WriteAsync("Hi there, I'm using the Use Method to call next middleware :)");
       // it'll calling next middleware by Httpcontext
        await _next(_context);

       // you can hit any logic code
    });

app.Use(async (HttpContext _context, RequestDelegate _next) =>
{

    await _context.Response.WriteAsync("Hi there, I'm the next middleware thank you to called me:)");
    // you can call another middleware it's possible 

    // you can hit any logic code 
});


app.Run();
