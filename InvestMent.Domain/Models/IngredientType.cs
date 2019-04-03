using InvestMent.Domain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Domain.Models
{
   public class IngredientType: IDomainEntity
    {
        public IngredientType(long Id, string Name,List<Ingredient> ingredients)
        {
            this.Id = Id;
            this.Name = Name;
            this.Ingredients = ingredients;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; }

    }
}
