using InvestMent.DAL.DTOs;
using InvestMent.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.DAL.Repository.IngredientsRepo
{
    public interface IIngredientRepository:IRepository<Ingredient>
    {
         Task<List<IngredientsDTO>> GetIngredientsNamesAndId();
    }
}
