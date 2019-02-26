using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Domain.Models
{
    public class Ingredient
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IngredientType Type { get; set; }
        public Brand IngredientBrand { get; set; }
    }
}
