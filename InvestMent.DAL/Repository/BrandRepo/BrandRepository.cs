using InvestMent.Application.Repository.BrandRepo;
using InvestMent.DAL.Converts;
using InvestMent.Domain.Models;
using InvestMent.Persistence.DBFirstApproach;

namespace InvestMent.DAL.Repository.BrandRepo
{
    public class BrandRepository:RepositoryBase<Persistence.DBFirstApproach.Brand, Domain.Models.Brand>,IBrandRepository
    {
        public BrandRepository(DbFirstContext context):base(context)
        {
        }

        public void AddOrUpdate(Domain.Models.Brand brand)
        {
            var entityIsInDb = DbContext.Brands.Find(brand.Id) != null;
            var trackedEntity = brand.Convert() as Persistence.DBFirstApproach.Brand; ;
            if (!entityIsInDb)
            {
                DbContext.Entry(trackedEntity).State = System.Data.Entity.EntityState.Added;
            }
            else
            {
                DbContext.Entry(trackedEntity).State = System.Data.Entity.EntityState.Modified;
            }
        }
    }
}
