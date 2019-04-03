using InvestMent.Domain.Interfaces.DAL;
using System;

namespace InvestMent.Domain.Models
{
    public class PancakeIngredients: IDomainEntity
    {
        public PancakeIngredients()
        {

        }
        public PancakeIngredients(Pancake pancake ,Ingredient ingredient)
        {
            Pancake = pancake;
            Ingredient = ingredient;
        }
        public PancakeIngredients(long Id,Pancake pancake, Ingredient ingredient)
        {
            this.Id = this.Id;
            PancakeId = pancake?.Id ?? 0;
            IngredientId = ingredient?.Id ?? 0; 
            Pancake = pancake;
            Ingredient = ingredient;
        }
        public PancakeIngredients(long coffeId, long ingredientId)
        {
            PancakeId = coffeId;
            IngredientId = ingredientId;
        }
        public long Id { get; set; }
        public long PancakeId { get; set; }
        public long IngredientId { get; set; }
        public Pancake Pancake { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}
