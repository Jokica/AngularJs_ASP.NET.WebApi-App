using InvestMent.DAL.DTOs;
using InvestMent.Domain.Interfaces.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestMent.Application.Repository.IngredientsRepo
{
    public interface IIngredientRepository:IRepository<IDataEntity, Domain.Models.Ingredient>
    {
        void AddOrUpdate(Domain.Models.Ingredient ingredient);
        Task<List<IngredientsDTO>> GetIngredientTypeNames();
    }
}
