
 /*
  * create directory called Controller to contain whole particular controller calss 
  * to implement specific action  via request from user then return respons from server
  * 
  * a controller in Asp.net core a class that contains a set of action  methods
  * and each of action controller acts as an endpoint
  */



var builder = WebApplication.CreateBuilder(args);

// Asp.net core shouled will be aware about controller directory
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();



app.Run();
