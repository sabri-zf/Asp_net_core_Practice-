using Microsoft.AspNetCore.Mvc;
using System.Net.Security;

namespace Asp.Net.Controllers.Controllers
{

    // classNmae with suffix "Controller" to help Asp.net core to hendle configration
    // befind the scenes
    // if use the middleware 
    public class HomeController
    {

        [Route("Home/{username:alpha}")]
        public string Home(string username)
        {
           

            if (username == null) return "Invalide the Username";

            return $"Hello Mr {username}";
        }

        // implement multiple routing Action

        [Route("Contact")]

        public ContentResult Contact()
        {
            return new()
            {
                Content = "<h1>Hello welcome to page contact</h1>",
                ContentType = "text/html",
                StatusCode = 200
            };
        }


        [Route("User")]
        public ContentResult User()
        {
            // return Content("Hello on user page !", "text/plain"); // it's the short-cut of contentResult class behind the scenes

            return new ContentResult()
            {
                Content = "Hello on user page !",
                ContentType = "text/plain",
                StatusCode = 200
            };
        }
    }
}
