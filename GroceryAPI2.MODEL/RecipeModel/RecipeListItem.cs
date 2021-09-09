using GroceryAPI2.MODEL.IngredientListModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryAPI2.MODEL.RecipeModel
{
    public class RecipeListItem
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public List<IngredientListDetail> IngredientList { get; set; }
        public string RecipeDescription { get; set; }
    }
}
