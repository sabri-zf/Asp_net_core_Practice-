
using build_Project_Using_ASP_NetCore;
using System.Text;

// create instance of WebApplication builder has a lot of components (serves,DI ... etc)
var builder = WebApplication.CreateBuilder(args);

// create instance of WebApplication
var app = builder.Build();


// generate 'Get' method of minimal Api
app.MapGet("/", (HttpContext context) =>
{
    var Path = context.Request.Path;
    context.Response.StatusCode = 200;
    context.Response.Headers["content-type"] = "text/html";

    var htmlcontent = new StringBuilder();

    htmlcontent.AppendLine("<!doctype html>");

    htmlcontent.AppendLine("<html>");

    htmlcontent.AppendLine("<head>");
    htmlcontent.AppendLine("<title> Sabri | main page</title>");
    htmlcontent.AppendLine("</head>");

    htmlcontent.AppendLine("<body>");
    htmlcontent.AppendLine("<h1>Pragamtic programmer</h1>");
    htmlcontent.AppendLine("</body>");

    htmlcontent.AppendLine("</html>");

    return htmlcontent.ToString();
}
);

app.Run(async (HttpContext context) =>
{
    if(context.Request.Path == "/" || context.Request.Path == "/Home")
    {
        context.Response.StatusCode = 200;

        await context.Response.WriteAsync("Welcome to Home Page");

        return;
    }

    if (context.Request.Path == "/player")
    {
            context.Response.StatusCode = 200;

        if (context.Request.Query.ContainsKey("id"))
        {
            int id = int.Parse(context.Request.Query["id"].ToString());

            await context.Response.WriteAsync(Players.ListPlayer[id - 1].ToString());

            return;
        }
        
        
        await context.Response.WriteAsync("Welcome to Players page");
        return;
    }


    if (context.Request.Path == "/Account")
    {
        context.Response.StatusCode = 200;

        if (context.Request.Method == "POST")
        {
            using (StreamReader reader = new StreamReader(context.Request.Body))
            {
                string Data = await reader.ReadToEndAsync();

                await context.Response.WriteAsync(Data);

            }

            return; archtictiure
        }

        await context.Response.WriteAsync("welcome to Account Page!");
    }


});

app.Run();
