using Microsoft.AspNetCore.Mvc;

namespace Asp.Net.Controllers.Controllers
{
    public class UseActionResultInstaedController:ControllerBase
    {

        ///<summary>
        ///We'll use IActionResult as Return Type To whole Action Type (File, Json ,.. so on)
        /// <see cref="ActionResult"/> is a perent class for all action Type 
        /// and it's implementing by <see cref="IActionResult"/> as interface
        /// 
        /// we use ActionResult to can specified several Action type result on methods
        ///</summary>
        ///

        public ActionResult Index()
        {

            if (System.IO.File.Exists("/simple.pdf")) 
            {
                return File("/simple.pdf", "application/pdf");
            }

            return Content("Hello we'll test the tiny of message", "text/plain");
        }
        

    }
}
