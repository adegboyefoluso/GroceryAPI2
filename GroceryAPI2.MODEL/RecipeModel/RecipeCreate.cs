using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryAPI2.MODEL.RecipeModel
{
    public class RecipeCreate
    {
        public string Name { get; set; }
        public string RecipeDescription { get; set; }
        public List<int> IngredientListIds { get; set; }
    }
}
