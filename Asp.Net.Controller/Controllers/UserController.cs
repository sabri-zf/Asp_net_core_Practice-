using Asp.Net.Controller.model;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net.Controllers.Controllers
{
    public class UserController
    {
        // in this controller we'll applying how can we returnt respons as JSON data
        // using JsonResult class on library ' Microsoft.AspNetCore.Mvc '


        [Route("User/{id}")]
        public JsonResult Name(int id)
        {

            var User = new User() { ID = 1, Name = "John smith", Age = 33 };

         //   return  json(User);// short-cut of jsonResult class behind the scenes;

            return new JsonResult(User);
        }




    }
}
