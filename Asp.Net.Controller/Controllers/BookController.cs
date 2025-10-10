using Microsoft.AspNetCore.Mvc;

namespace Asp.Net.Controllers.Controllers
{
    /// <summary>
    /// in this class we'll create Action method with status code result 
    /// </summary>
    public class BookController:ControllerBase
    {


        [Route("Books")]

        public IActionResult Book()
        {
            if(!Request.Query.ContainsKey("BookId"))
            {
                return new BadRequestObjectResult("your request has been failed");
            }

            var Bookid = Convert.ToInt32(Request.Query["BookId"]);

            if(Bookid < 1 ||  Bookid > 100)
            {
                return new NotFoundObjectResult("Data not Found");
            }


            if (!Convert.ToBoolean(Request.Query["LogIn"]))
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            return  File("/Simple.pdf", "appliaction/pdf");
        }
    }
}
