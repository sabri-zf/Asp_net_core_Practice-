using overcome_Routing.customeRoutingConstarint;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // regester coustme reouting constraint 

        builder.Services.AddRouting(Config =>
        {
            //Config.ConstraintMap.Clear();
            Config.ConstraintMap.Add("MonthNumeric", typeof(MonthNumircConstraint));
        });

        var app = builder.Build();


        // select endpoint via middleware

        //note: when you set the middleware to get endpoint of http request 
        // you should set it after routing method middleware 
        // 
        //app.Use(async (context, next) =>
        //{
        //    Endpoint? endpoint = context.GetEndpoint();
        //    if (endpoint is not Endpoint)
        //    {
        //        // do action
        //    }
        //    await next(context);
        //});


        // Routing is a procees of matching incoming request 
        // to a give (action /function) based on the URL and the Request HTTP Method (GET , POST , PUT ....etc)
        // Routing = URL + Http Method

        // defined Routing middleware 
        // it enable routing in Asp.net 
        app.UseRouting();

        //app.Use(async (context, next) =>
        //{
        //    Endpoint? endpoint = context.GetEndpoint();
        //    if (endpoint is  Endpoint)
        //    {
        //        await context.Response.WriteAsync(endpoint.DisplayName);
        //        // do action
        //    }
        //    await next(context);
        //});

        // we can defiend all routings in UseEndpoint
        app.UseEndpoints(async endpoints =>
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


            // routing parameters are named URL segments that are used to capture
            //the values specified at thier position. the value of routing parameter can change
            endpoints.MapGet("/Books/aouther/{AoutherName}/{id}", async context =>
            {
                int id = Convert.ToInt32(context.Request.RouteValues["id"]);
                string aoutherName = context.Request.RouteValues["AoutherName"].ToString();
                await context.Response.WriteAsync($"This book has id = {id} , Aouther = {aoutherName}");
            });

            // use the default (=) routing on  URl Requerst

            endpoints.MapGet("/User/{username}/{Password= 1234}", async context =>
            {
                string UserName = context.Request.RouteValues["username"].ToString();
                string passWord = context.Request.RouteValues["password"].ToString();
                await context.Response.WriteAsync($"Hello {UserName} , your password is {passWord}");
            });


            // optional (?) routing value on URL Request

            endpoints.MapGet("/employees/{username}/{Role?}/", async context =>
            {

                string UserName = context.Request.RouteValues["username"].ToString();
                var Role = context.Request.RouteValues["Role"];

                if (Role is not null)
                {

                    Role = Role.ToString();

                    await context.Response.WriteAsync($"Hello {UserName}, your Role : {Role}");

                    return;
                }

                await context.Response.WriteAsync("Welcome to User Page :)");
            });


            // set constraint routing datatype 

            endpoints.MapGet("/Inventory/{id:int}", async context =>
            {
                // if the request id doesn't matching datat type 
                // it'll be escape execution of this endpoint response

                int id = Convert.ToInt32(context.Request.RouteValues["id"]);

                await context.Response!.WriteAsync($"Hi there, ID : {id}");
            });

            // set constaraint routing datatype using Alpha 

            endpoints.MapGet("/Admin/{username:alpha}", async context =>
                {

                    var NameUser = context.Request.RouteValues["username"];

                    if (NameUser is not string)
                    {

                        NameUser = NameUser.ToString();
                        await context.Response!.WriteAsync("User Name Has not been Existed");
                        return;
                    }


                    await context.Response.WriteAsync($"Hello user :) => {NameUser}");
                });

            //using constarint to alph datatype

            endpoints.MapGet("recuituer/{employee:alpha:minlength(5):maxlength(10)}", async context =>
            {
                var employeeName = context.Request.RouteValues["employee"];

                if (employeeName is null)
                {
                    employeeName = Convert.ToString(employeeName);
                    await context.Response.WriteAsync("The recuituer doesn't exist");
                    return;
                }

                await context.Response.WriteAsync($"Hello, Mr {employeeName}");

            });

            endpoints.MapGet("recuituer/{employee:alpha:length(5,15)}", async context =>
            {
                var employeeName = context.Request.RouteValues["employee"];

                if (employeeName is null)
                {
                    employeeName = Convert.ToString(employeeName);
                    await context.Response.WriteAsync("The recuituer doesn't exist");
                    return;
                }

                await context.Response.WriteAsync($"Hello, Mr {employeeName}");

            });


            // set constraint min and max and reage


            //endpoints.MapGet("/Inventories/{id:int:min(10):max(100)}", async context =>
            //{
            //    // if the request id doesn't matching datat type 
            //    // it'll be escape execution of this endpoint response

            //    int id = Convert.ToInt32(context.Request.RouteValues["id"]);

            //    await context.Response!.WriteAsync($"Hi there, ID : {id}");
            //});

            endpoints.MapGet("/Inventories/{id:int:range(11,101)}", async context =>
            {
                // if the request id doesn't matching datat type 
                // it'll be escape execution of this endpoint response

                int id = Convert.ToInt32(context.Request.RouteValues["id"]);

                await context.Response!.WriteAsync($"Hi there, ID : {id}");
            });


            // USE REGNX CONSTAINT ON ROUTE URL

            endpoints.MapGet("/management/{Admin:alpha:regex(^(sabri|ahmmed|Zaki)$)}", async (Context) =>
            {

                var val = Context.Request.RouteValues["Admin"];

                if (val is not null)
                {
                    val = Convert.ToString(val);

                    await Context.Response.WriteAsync($"Hello Mr {val}");
                    return;
                }

                await Context.Response.WriteAsync("you don't have licence to open up window", Encoding.ASCII);
            });

            // use Regex constarint on number 

            endpoints.MapGet("/dates/{Date:regex(^(19|20)\\d\\d[/ -](0[1-9]|1[012])$)}", async (Context) =>
            {

                var val = Context.Request.RouteValues["Date"];

                if (val is not null)
                {
                    val = Convert.ToString(val);

                    await Context.Response.WriteAsync($"your schedule date is : {val}");
                    return;
                }

                await Context.Response.WriteAsync("your date doesn't acceptable", Encoding.ASCII);
            });


            // use custome route constarint via implement calss inherate from IRouteConstatint 
            // then regester it on serverCollection

            endpoints.MapGet("Date/{Year= 2010}/{Month:MonthNumeric}", async (context) =>
            {

                short year = Convert.ToInt16(context.Request.RouteValues["Year"]);
                byte month = Convert.ToByte(context.Request.RouteValues["Month"]);

                await context.Response.WriteAsync($"The date is {year}-{month}");
            });

        });


        app.Run(async context =>
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync($" 404 :( , The page you've been requsted not found");
        });


        app.Run();
    }
}