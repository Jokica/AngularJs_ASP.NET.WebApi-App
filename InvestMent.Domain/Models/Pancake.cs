using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Domain.Models
{
    public class Pancake
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PancakeIngredients> Ingredients { get; set; }
        public Brand CoffeBrand { get; set; }
    }
}
