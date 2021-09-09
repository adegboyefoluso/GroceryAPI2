using GroceryAPI2.MODEL.IngredientListModel;
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
    public class IngredientListController : ApiController
    {
        private IngredientListServices CreateIngredientListServices()
        {
            var userid = Guid.Parse(User.Identity.GetUserId());
            var services = new IngredientListServices(userid);
            return services;
        }


        [HttpPost]
        public IHttpActionResult Post(IngredientListCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateIngredientListServices();

            if (!service.CreateIngredientList(model))
                return InternalServerError();

            return Ok("Recipe Created Successfully");
        }
        [HttpGet]
        public IHttpActionResult GetAllIngredeientList()
        {
            var service = CreateIngredientListServices();
            var ingredientlist = service.GetAllIngredientList();
            return Ok(ingredientlist);

        }
        [HttpGet]
        public IHttpActionResult GetShoppingList(int id)
        {
            var service = CreateIngredientListServices();
            var ingredientlist = service.GetIngredientListById(id);
            if (ingredientlist is null)
                return InternalServerError();
            return Ok(ingredientlist);
        }
       
        [Route("api/IngredientList/GetRecipe{id}")]
        [HttpGet]
        public IHttpActionResult GetIngredientListByRecipeId(int id)
        {
            var service = CreateIngredientListServices();
            var ingredientlist = service.GetRecipesByIngredientListId(id);
            if (ingredientlist is null) 
                return InternalServerError();
            return Ok(ingredientlist);
        }

    }
}
