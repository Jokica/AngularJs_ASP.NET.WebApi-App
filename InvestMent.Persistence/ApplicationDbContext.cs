using InvestMent.Domain.Models;
using InvestMent.Domain.Models.IdentityModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace InvestMent.Persistence
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Brand> Brand { get; set; }
        public DbSet<PancakeIngredients> CoffeIngredients { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Pancake> Pancakes { get; set; }
        public DbSet<IngredientType> IngredientType { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
