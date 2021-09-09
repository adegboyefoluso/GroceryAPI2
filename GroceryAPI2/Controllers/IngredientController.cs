using GroceryAPI2.MODEL.IngredientModel;
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
    public class IngredientController : ApiController
    {
        private IngredientService CreateIngredientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ingredientService = new IngredientService(userId);
            return ingredientService;
        }

        // GET
        public IHttpActionResult Get()
        {
            IngredientService ingredientService = CreateIngredientService();
            var ingredients = ingredientService.GetIngredients();
            return Ok(ingredients);
        }

        // POST
        public IHttpActionResult Post(IngredientCreate ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IngredientService service = CreateIngredientService();

            if (!service.CreateIngredient(ingredient))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
