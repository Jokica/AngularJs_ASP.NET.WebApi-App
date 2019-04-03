using InvestMent.Domain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Persistence.DBFirstApproach
{
    public partial class IngredientType : IDataEntity
    {
        public IDomainEntity Convert()
        {
            var list = this.Ingredients.Select(x => x.Convert() as Domain.Models.Ingredient).ToList();
            return new Domain.Models.IngredientType(
                    this.Id,
                    this.Name,
                    list
                );
        }
    }
}
