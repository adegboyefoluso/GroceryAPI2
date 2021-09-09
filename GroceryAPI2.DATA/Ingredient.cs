using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryAPI2.DATA
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public bool IsOrganic { get; set; }
        public virtual ICollection<IngredientList> IngredientsList { get; set; }
        public Guid OwnerId { get; set; }
        public Ingredient()
        {
            IngredientsList = new HashSet<IngredientList>();
        }
        public int AmountOfIngredient { get; set; }
    }
}
