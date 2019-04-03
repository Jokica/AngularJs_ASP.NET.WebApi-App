using InvestMent.Domain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Persistence.DBFirstApproach
{
    public partial class PancakeIngredient : IDataEntity
    {
        public IDomainEntity Convert()
        {
            return new Domain.Models.PancakeIngredients(
                    this.Id,
                    this.Ingredient.Convert() as Domain.Models.Pancake,
                    this.Pancake.Convert() as Domain.Models.Ingredient
                ); 
        }
    }
}
