using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryAPI2.MODEL.IngredientListModel
{
    public class IngredientListEdit
    {
        public int IngredientListId { get; set; }
        public string Name { get; set; }
        public List<int> IngredientIds { get; set; }
    }
}
