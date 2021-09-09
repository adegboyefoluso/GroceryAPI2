using GroceryAPI2.DATA;
using GroceryAPI2.MODEL.RecipeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryAPI2.Services
{
    public class RecipeService
    {
        private readonly Guid _UserId;
        public RecipeService(Guid userid)
        {
            _UserId = userid;
        }

        public bool AddRecipe(RecipeCreate model)
        {
            List<int> integers = new List<int>();
            var recipe = new Recipe()
            {
                Name = model.Name,
                CreatedUtc = DateTimeOffset.Now,
                RecipeDescription = model.RecipeDescription
            };
            using (var ctx= new ApplicationDbContext())
            {
                foreach (var id in model.IngredientListIds)
                {
                    var query = ctx
                                   .IngredientLists
                                   .SingleOrDefault(i => i.IngredientListId == id);
                    if (query is null)
                    {
                        integers.Add(id);
                        if (integers.Count == model.IngredientListIds.Count)
                            return false;
                        continue;
                    }
                    recipe.IngredientLists.Add(query);
                }
                ctx.Recipes.Add(recipe);
                return ctx.SaveChanges() == 1;
            }
            
        }
    }
}
