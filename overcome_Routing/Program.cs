var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Routing is a procees of matching incoming request 
// to a give (action /function) based on the URL and the Request HTTP Method (GET , POST , PUT ....etc)
// Routing = URL + Http Method


// defined Routing middleware 
// it enable routing in Asp.net 
app.UseRouting();


// we can defiend all routings in UseEndpoint
app.UseEndpoints(endpoints =>
{
    // map using for whole requests (get,post, delet, put)
    endpoints.Map("/Home", async context =>
        {
            await context.Response.WriteAsync("Hello , welcome to Home Page");
        });

    endpoints.MapGet("/Inventory", async context =>
    {
        await context.Response!.WriteAsync("Hi there, you're on Iverntory Page :)");
    });

});


app.Run( async context =>
{
    await context.Response.WriteAsync($" 404 :( , The page you've been requsted not found");
});

 
app.Run();
