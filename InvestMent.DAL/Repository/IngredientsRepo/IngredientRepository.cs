using InvestMent.DAL.DTOs;
using InvestMent.Domain.Models;
using InvestMent.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        Task<List<IngredientsDTO>> IIngredientRepository.GetIngredientsNamesAndId()
        {
            return this.Context.Ingredient.Select(s => new IngredientsDTO {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();
        }
    }
}
