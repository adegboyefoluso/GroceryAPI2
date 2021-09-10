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
        [Route("api/IngredientList/AddIngredient")]
        [HttpPost]
        public IHttpActionResult AddIngredientToIngredientList(DeleteIngredient model)
        {
            var service = CreateIngredientListServices();
            var ingredientlist = service.AddIngredientToIngredientList(model);
            if (ingredientlist is false)
                return InternalServerError();
            return Ok("Ingredient succesfully Added");
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
        [HttpDelete]
        public IHttpActionResult DeleteIngredientFromIngredientList(DeleteIngredient model)
        {
            var service = CreateIngredientListServices();
            var ingredientlist = service.DeleteIngredientfromIngredientList(model);
            if (ingredientlist is false)
                return InternalServerError();
            return Ok("Ingredient succesfully deleted");
        }
        [HttpDelete]
        public IHttpActionResult DeleteIngredientList(int id)
        {
            var service = CreateIngredientListServices();
            var ingredientlist = service.DeleteIngredientList(id);
            if (ingredientlist is false)
                return InternalServerError();
            return Ok("Ingredient succesfully deleted");
        }


    }
}
