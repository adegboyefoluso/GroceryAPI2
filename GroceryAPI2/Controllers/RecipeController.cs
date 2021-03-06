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

        [HttpGet]
        public IHttpActionResult GetAllRecipeById(int id)
        {
            var service = CreateRecipeServices();
            var recipes = service.GetRecipeById(id);
            return Ok(recipes);
        }

        [Route("api/Recipe/RecipeByName/{name}")]
        [HttpGet]
        public IHttpActionResult GetRecipeByName(string name)
        {
            var service = CreateRecipeServices();
            var recipes = service.GetRecipeByName(name);
            return Ok(recipes);
        }


        [Route("api/Recipe/IngredientId/{id}")]
        [HttpGet]
        public IHttpActionResult GetRecipeByIngredinetId(int id)
        {
            var service = CreateRecipeServices();
            var recipes = service.GetRecipeSByIngredient(id);
            return Ok(recipes);
        }
    }
}
