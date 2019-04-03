using System.Collections.Generic;
using System.Threading.Tasks;
using InvestMent.Application.Repository.IngredientsRepo;
using InvestMent.DAL.Converts;
using InvestMent.DAL.DTOs;
using InvestMent.Persistence.DBFirstApproach;
using Ingredient = InvestMent.Persistence.DBFirstApproach.Ingredient;

namespace InvestMent.DAL.Repository.IngredientsRepo
{
    public class IngredientRepository:RepositoryBase<Ingredient,Domain.Models.Ingredient>,IIngredientRepository
    {
        public IngredientRepository(DbFirstContext applicationDbContext):base(applicationDbContext)
        {
        }
        public void AddOrUpdate(Domain.Models.Ingredient ingredient)
        {
            var entityIsInDb = DbContext.Brands.Find(ingredient.Id) != null;
            var trackedEntity = ingredient.Convert() as Persistence.DBFirstApproach.Ingredient; 
            if (!entityIsInDb)
            {
                DbContext.Entry(trackedEntity).State = System.Data.Entity.EntityState.Added;
            }
            else
            {
                DbContext.Entry(trackedEntity).State = System.Data.Entity.EntityState.Modified;
            }
        }

        public Task<List<IngredientsDTO>> GetIngredientTypeNames()
        {
           return DbContext.Database.SqlQuery<IngredientsDTO>("Select * from GetAlltypeNamesVW").ToListAsync();
        }
    }
}
