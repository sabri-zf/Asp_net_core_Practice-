using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace RedirectionAction.Asp.Net.Core.controllers
{
    public class VipFoodController:Controller
    {


        [Route("/Foods/Vip")]
        public IActionResult VipFood()
        {
            return Content("the food Vip has been ready to eat", "text/plain", Encoding.ASCII);
        }

    }
}
