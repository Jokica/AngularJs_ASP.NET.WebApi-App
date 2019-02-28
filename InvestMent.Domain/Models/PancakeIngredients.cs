using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Domain.Models
{
    public class PancakeIngredients
    {
        public PancakeIngredients()
        {

        }
        public PancakeIngredients(Pancake pancake ,Ingredient ingredient)
        {
            Pancake = pancake;
            Ingredient = ingredient;
        }
        public PancakeIngredients(long coffeId, long ingredientId)
        {
            CoffeId = coffeId;
            IngredientId = ingredientId;
        }
        public long Id { get; set; }
        public long CoffeId { get; set; }
        public long IngredientId { get; set; }
        public Pancake Pancake { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
