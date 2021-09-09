using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryAPI2.DATA
{
    public class IngredientList
    {

        [Key]
        public int IngredientListId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public IngredientList()
        {
            Ingredients = new HashSet<Ingredient>();

        }
    }
}
