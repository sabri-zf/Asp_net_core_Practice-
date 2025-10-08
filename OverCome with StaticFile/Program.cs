
///
// static file in Asp.net core one way to rendering file like HTML , CSS , Js , txt ... so on
// Asp.net specified default directory to live files on it called "wwwroot"
// can also set custome directory and lay it as default root directory 
// and can add more directory of static files 
// if route doesn't find the file on the default, it'll be look for it on other static files directory
///






using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    WebRootPath = "StaticFiles" // set as defualt root web static files
});

var app = builder.Build();


// this extension used when the defualt directory it's wwwroot or customize another 
// WebRoot 
app.UseStaticFiles();

// make secend static files path middleware

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "MyStaticFiles"))
});

app.MapGet("/", () => "Hello World!");

app.Run();
