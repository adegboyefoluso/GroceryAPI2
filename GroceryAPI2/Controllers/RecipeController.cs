using GroceryAPI2.MODEL.RecipeModel;
using GroceryAPI2.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GroceryAPI2.Controllers
{
    [Authorize]
    public class RecipeController : ApiController
    {
        private RecipeService CreateRecipeServices()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var services = new RecipeService(userid);
            return services;
        }

        [HttpPost]
        public IHttpActionResult Post(RecipeCreate recipe)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRecipeServices();

            if (!service.AddRecipe(recipe))
                return InternalServerError();

            return Ok("Recipe Created Successfully");
        }
        [HttpGet]
        public IHttpActionResult GetAllRecipe()
        {
            var service = CreateRecipeServices();
            var recipes = service.GetALlRecipe();
            return Ok(recipes);
        }
    }
}
