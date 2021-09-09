using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryAPI2.DATA
{
   public  class Recipe
    {

        [Key]
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public Guid OwnerId { get; set; }
        public string RecipeDescription { get; set; }
        public virtual ICollection<IngredientList> IngredientLists { get; set; } = new List<IngredientList>();
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
