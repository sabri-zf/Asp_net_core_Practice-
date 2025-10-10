using Microsoft.AspNetCore.Mvc;

namespace RedirectionAction.Asp.Net.Core.controllers
{
    public class StoreController:Controller
    {



        [Route("Books")]
        public IActionResult Redirection_TryGetBookByID(int BookId)
        {
            return new ContentResult()
            {
                Content = "You're in new redirection page called category books",
                ContentType = "text/plain",
                StatusCode = StatusCodes.Status200OK,
            };

        }

    }
}
