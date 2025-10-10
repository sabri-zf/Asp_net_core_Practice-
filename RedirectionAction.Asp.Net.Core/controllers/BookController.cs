using Microsoft.AspNetCore.Mvc;

namespace RedirectionAction.Asp.Net.Core.controllers
{

    /// <summary>
    /// in this Demo class we'll simulate a scenario of how to redirection route request to new one 
    /// 
    /// but how redirection work :
    /// 
    /// ---- 1 - : the client send request to server via orginal url have been known 
    /// ---- 2 - : the server send back respons with status code 301 or 302 mean (temproryly or permanently) change localtion
    ///             with new laction where New Url reside
    ///----- 3 - : then the client send request with new url to catch respons from server
    /// </summary>
    /// 
    
    public class BookController:Controller
    {

        [Route("Books")]

        public IActionResult TryGetBookByID(int bookId)
        {
            if (bookId < 1) new BadRequestObjectResult($"Failed: Book ID '{bookId}' isn't valid");


            // 301 mean => move Url (permentaly)
            //302 mean => move url (temproryly)
            return new RedirectToActionResult("Redirection_TryGetBookByID", "Store",null,true);
        }


      
    }
}
