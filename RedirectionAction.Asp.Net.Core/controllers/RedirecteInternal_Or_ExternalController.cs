using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace RedirectionAction.Asp.Net.Core.controllers
{
    public class RedirecteInternal_Or_ExternalController:Controller
    {


        [Route("/Games")] // Path name => URI
        public IActionResult Foods()
        {
            // redirecte internal
            //return new LocalRedirectResult("/Foods/Vip",true);

            // redirecte external 
            // 301 => Found 
            // 302 => Move permanently
            // 307 => redirect temporaryly
            // 308 => Redirect Permanently
            return new RedirectResult("https://www.google.com");
        }


      
    }
}
