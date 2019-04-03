using InvestMent.Domain.Models;
using InvestMent.Domain.Models.IdentityModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace InvestMent.Persistence
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
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
