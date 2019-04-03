using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using InvestMent.Domain.Interfaces.DAL;
using InvestMent.Application.Repository;
using InvestMent.Persistence.DBFirstApproach;
using InvestMent.DAL.Converts;

namespace InvestMent.DAL.Repository
{
    public  class RepositoryBase<T,U> : IRepository<T,U> where T: class, IDataEntity where U : class,IDomainEntity
    {
        private readonly DbContext context;

        public RepositoryBase(DbContext context)
        {
            this.context = context;
        }
        public void Add(U newItem)
        {
            this.context.Set<T>().Add(newItem.Convert() as T);
        }

        public void AddRange(ICollection<U> itemRange)
        {
            var items = itemRange.Select(x => x.Convert() as T);
            context.Set<T>().AddRange(items);
        }

        public IEnumerable<U> All(bool asNoTracking)
        {
            var items = asNoTracking?  context.Set<T>().AsNoTracking(): context.Set<T>();
            return items.ToList().Select(x => x.Convert() as U);
        }
        public bool Remove(U item)
        {
           return  context.Set<T>().Remove(item.Convert() as T) != null;
        }
        public bool RemoveRange(ICollection<U> itemRange)
        {
            var items = itemRange.Select(x => x.Convert() as T);
            return context.Set<T>().RemoveRange(items) != null;
        }

        public async Task<List<U>> AllAsync(bool asNoTracking)
        {
            var items = asNoTracking? await context.Set<T>().AsNoTracking().ToListAsync(): await context.Set<T>().ToListAsync();
            return items.Select(x => x.Convert() as U).ToList();
        }
        public async Task<U> FindAsync(long Id, List<string> includes)
        {
            includes = includes ?? new List<string>();
            var entities = context.Set<T>();
            foreach (string include in includes)
            {
                entities.Include(include);
            }
            var item = await entities.FindAsync(Id);
            return item.Convert() as U;
        }

        public U Find(long Id, List<string> includes )
        {
            includes = includes ?? new List<string>();
            var entities = context.Set<T>();
            foreach (string include in includes)
            {
                entities.Include(include);
            }
            return entities.Find(Id).Convert() as U;
        }

        public U Find(long Id)
        {
            return context.Set<T>().Find(Id).Convert() as U;

        }
        public async Task<U> FindAsync(long Id)
        {
            var res  = await context.Set<T>().FindAsync(Id);
            return res.Convert() as U;

        }
        public DbFirstContext DbContext => this.context as DbFirstContext;
    }
}
