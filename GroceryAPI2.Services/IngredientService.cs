using GroceryAPI2.DATA;
using GroceryAPI2.MODEL.IngredientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryAPI2.Services
{
    public class IngredientService
    {
        private readonly Guid _userId;
        public IngredientService(Guid userid)
        {
            _userId = userid;
        }

        // Create
        public bool CreateIngredient(IngredientCreate model)
        {
            var entity =
                new Ingredient()
                {
                    Name = model.Name,
                    IsOrganic = model.IsOrganic,

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ingredients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read
        public IEnumerable<IngredientListItem> GetIngredients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ingredients
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new IngredientListItem
                        {
                            IngredientId = e.IngredientId,
                            Name = e.Name,
                            IsOrganic = e.IsOrganic
                        }
                        );
                return query.ToArray();
            }
        }

        // Update

        // Delete

    }
}

