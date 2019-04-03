using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InvestMent.Application.Repository.PancakeRepo;
using InvestMent.DAL.Converts;
using InvestMent.Domain.Interfaces.DAL;
using InvestMent.Domain.Models;
using InvestMent.Persistence.DBFirstApproach;

namespace InvestMent.DAL.Repository.PancakeRepo
{
    public class PancakeRepository:RepositoryBase<Persistence.DBFirstApproach.Pancake,Domain.Models.Pancake>,IPancakeRepository
    {
        public PancakeRepository(DbFirstContext context):base(context)
        {
        }
        public void AddOrUpdate(Domain.Models.Pancake pancake)
        {
            var entityIsInDb = DbContext.Brands.Find(pancake.Id) != null;
            var trackedEntity = pancake.Convert() as Persistence.DBFirstApproach.Pancake;
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
