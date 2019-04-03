using InvestMent.Domain.Interfaces.DAL;
using System;

namespace InvestMent.Domain.Models
{
    public class Ingredient: IDomainEntity
    {
        public Ingredient(long id ,string name,IngredientType type, Brand brand)
        {
            Id = id;
            Name = name;
            Type = type;
            TypeId = type?.Id ?? 0;
            IngredientBrand = brand;
            IngredientBrandId = brand?.Id;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public IngredientType Type { get; set; }
        public long TypeId { get; set; }
        public Brand IngredientBrand { get; set; }
        public long? IngredientBrandId { get; set; }
    }
}
