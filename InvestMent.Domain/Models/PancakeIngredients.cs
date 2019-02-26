using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Domain.Models
{
    public class PancakeIngredients
    {
        public long Id { get; set; }
        public long CoffeId { get; set; }
        public long IngredientId { get; set; }
        public Pancake Pancake { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
