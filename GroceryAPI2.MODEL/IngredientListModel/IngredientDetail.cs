using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryAPI2.MODEL.IngredientListModel
{
    public class IngredientDetail
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public double IngredientAmount { get; set; }
        public bool IsOrganic { get; set; }
    }
}
