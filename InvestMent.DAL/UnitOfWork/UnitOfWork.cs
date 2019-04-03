using System.Threading.Tasks;
using InvestMent.Application.Repository.BrandRepo;
using InvestMent.Application.Repository.IngredientsRepo;
using InvestMent.Application.Repository.PancakeRepo;
using InvestMent.Application.UnitOfWork;
using InvestMent.DAL.Repository.BrandRepo;
using InvestMent.DAL.Repository.IngredientsRepo;
using InvestMent.DAL.Repository.PancakeRepo;
using InvestMent.Persistence.DBFirstApproach;

namespace InvestMent.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbFirstContext context;

        public UnitOfWork(DbFirstContext context)
        {
            this.context = context;
            Pancakes = new PancakeRepository(context);
            Brand = new BrandRepository(context);
            Ingridents = new IngredientRepository(context);
        }
        public IPancakeRepository Pancakes { get; private set; }

        public IBrandRepository Brand { get; private set; }

        public IIngredientRepository Ingridents { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }
        public Task<int> CompleteAsync()
        {
            return context.SaveChangesAsync();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
