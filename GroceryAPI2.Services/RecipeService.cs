using GroceryAPI2.DATA;
using GroceryAPI2.MODEL.IngredientListModel;
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
                RecipeDescription = model.RecipeDescription,
                OwnerId=_UserId
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
                return ctx.SaveChanges() >= 1;
            }
            
        }
        //Get All recipe
        public IEnumerable<RecipeListItem> GetALlRecipe()
        {
            using (var ctx =new ApplicationDbContext())
            {
                var recipe = ctx
                                .Recipes
                                .Select(e => new RecipeListItem
                                {
                                    RecipeId = e.RecipeId,
                                    RecipeDescription = e.RecipeDescription,
                                    Name = e.Name,
                                    IngredientList = e.IngredientLists
                                                    .Select(c => new IngredientListDetail()
                                                    {
                                                        IngredientListId = c.IngredientListId,
                                                        IngredientListName = c.Name,
                                                        ListOfIngredientDetails = c.Ingredients
                                                                                  .Select(d => new IngredientDetail
                                                                                  {
                                                                                      IngredientId = d.IngredientId,
                                                                                      IngredientName = d.Name,
                                                                                      IsOrganic = d.IsOrganic
                                                                                  }).ToList()


                                                    }).ToList()
                                }).ToList();
                return recipe;
            }
        }

        //Get Recipe By Recipe Id
        public  RecipeListItem GetRecipeById(int id)
        {
            using (var ctx=new ApplicationDbContext())
            {
                var query = ctx
                                .Recipes
                                .SingleOrDefault(e => e.RecipeId == id);
                if (query is null)
                    return null;
                return new RecipeListItem()
                {
                    RecipeId = query.RecipeId,
                    Name = query.Name,
                    RecipeDescription = query.RecipeDescription,
                    IngredientList = query.IngredientLists
                                                    .Select(c => new IngredientListDetail()
                                                    {
                                                        IngredientListId = c.IngredientListId,
                                                        IngredientListName = c.Name,
                                                        ListOfIngredientDetails = c.Ingredients
                                                                                  .Select(d => new IngredientDetail
                                                                                  {
                                                                                      IngredientId = d.IngredientId,
                                                                                      IngredientName = d.Name,
                                                                                      IsOrganic = d.IsOrganic
                                                                                  }).ToList()


                                                    }).ToList()

                };
                                
            }
        }
        //Delete A recipe
        public bool DeleteRecipe(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Recipes
                                .SingleOrDefault(e => e.OwnerId == _UserId && e.RecipeId == id);
                if (query is null)
                    return false;
                ctx.Recipes.Remove(query);
                return ctx.SaveChanges() == 1;
            }
        }
        //Edit A Recipe

       // Get Recipe By Name
       public IEnumerable< RecipeListItem> GetRecipeByName(string name)
        {
            using(var ctx =new ApplicationDbContext())
            {
                var recipe = ctx
                                .Recipes
                                .Where(e => e.Name.Contains(name))
                                .Select(e => new RecipeListItem()
                                {
                                    RecipeId = e.RecipeId,
                                    Name = e.Name,
                                    RecipeDescription = e.RecipeDescription,
                                    IngredientList = e.IngredientLists
                                                    .Select(c => new IngredientListDetail()
                                                    {
                                                        IngredientListId = c.IngredientListId,
                                                        IngredientListName = c.Name,
                                                        ListOfIngredientDetails = c.Ingredients
                                                                                  .Select(d => new IngredientDetail
                                                                                  {
                                                                                      IngredientId = d.IngredientId,
                                                                                      IngredientName = d.Name,
                                                                                      IsOrganic = d.IsOrganic
                                                                                  }).ToList()


                                                    }).ToList()

                                }).ToList();
                return recipe;
            }
        }

        public IEnumerable<Recipe> GetRecipeSByIngredient(int id)
        {
            using (var ctx =new ApplicationDbContext())
            {
                List<Recipe> list = new List<Recipe>();
                var recipe = ctx
                                .Recipes.ToList();
                foreach (var item in recipe)
                {
                    foreach(var c in item.IngredientLists)
                    {
                        foreach (var d in c.Ingredients)
                        {
                            if (d.IngredientId == id)
                            {
                                list.Add(item);
                            }
                        }
                    }
                }
                return list;
                  
            }
        }
    }
}
