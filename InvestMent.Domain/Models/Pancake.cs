using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Domain.Models
{
    public class Pancake
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PancakeIngredients> Ingredients { get; set; }
        public Brand CoffeBrand { get; set; }
        public string ImageURL { get; set; }
        public Pancake()
        {

        }

        public Pancake(string name,string imageUrl)
        {
            ImageURL = imageUrl;
            Name = Name;
        }
        public Pancake(string name, Brand brand,string imageUrl)
        {
            Name = name;
            CoffeBrand = brand;
            ImageURL = imageUrl;
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
