using InvestMent.Domain.Models;
using InvestMent.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.DAL.Repository.IngredientsRepo
{
    public class IngredientRepository:RepositoryBase<Ingredient>,IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
