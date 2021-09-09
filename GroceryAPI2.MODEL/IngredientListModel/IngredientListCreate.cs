using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryAPI2.MODEL.IngredientListModel
{
    public class IngredientListCreate
    {
        public string Name { get; set; } //Ingredientlist for Donut  //flour 1, sugar 2, oil 3
        public List<int> IngredientIds { get; set; }

    }
}
