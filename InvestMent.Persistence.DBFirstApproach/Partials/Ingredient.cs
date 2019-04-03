using InvestMent.Domain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Persistence.DBFirstApproach
{
    public partial class Ingredient : IDataEntity
    {
        public IDomainEntity Convert()
        {
            return new Domain.Models.Ingredient(
                    this.Id,
                    this.Name,
                    this.IngredientType.Convert() as Domain.Models.IngredientType,
                    this.Brand.Convert() as Domain.Models.Brand
                    );
        }
    }
}
