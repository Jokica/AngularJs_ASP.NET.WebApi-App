using InvestMent.Domain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Persistence.DBFirstApproach
{
    public partial class Pancake : IDataEntity
    {
        public IDomainEntity Convert()
        {
            var list = this.PancakeIngredients.Select(x => x.Convert() as Domain.Models.PancakeIngredients).ToList();
            return new Domain.Models.Pancake(
                    this.Id,
                    this.Name,
                    list,
                    this.ImageURL
                );
        }
    }
}
