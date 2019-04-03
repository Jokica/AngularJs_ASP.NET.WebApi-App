using InvestMent.Domain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Domain.Models
{
    public class Pancake: IDomainEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PancakeIngredients> Ingredients { get; set; }
        public string ImageURL { get; set; }
        public Pancake()
        {

        }
        public Pancake(long Id, string name, List<PancakeIngredients> ingredients, string imageUrl )
        {
            this.Id = Id;
            this.Ingredients = ingredients;
            this.ImageURL = imageUrl;
            Name = name;
        }
        public void AddIngredients(List<Ingredient> ingredients)
        {
            ingredients.ForEach(AddIngredient);
        }
        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(new PancakeIngredients(this, ingredient));
        }
    }
}
