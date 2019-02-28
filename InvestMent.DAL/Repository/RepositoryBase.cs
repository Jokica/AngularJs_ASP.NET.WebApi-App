using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Linq;
using InvestMent.Persistence;
using System.Threading.Tasks;

namespace InvestMent.DAL.Repository
{
    public abstract class RepositoryBase<T> : IRepository<T> where T:class
    {
        private readonly DbContext context;

        public RepositoryBase(DbContext context)
        {
            this.context = context;
        }
        public void Add(T newItem)
        {
            this.context.Set<T>().Add(newItem);
        }

        public void AddRange(ICollection<T> itemRange)
        {
            context.Set<T>().AddRange(itemRange);
        }

        public IEnumerable<T> All(bool asNoTracking)
        {
            return asNoTracking?  context.Set<T>().AsNoTracking(): context.Set<T>();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }
        public bool Remove(T item)
        {
           return  context.Set<T>().Remove(item) != null;
        }
        public bool RemoveRange(ICollection<T> itemRange)
        {
            return context.Set<T>().RemoveRange(itemRange) != null;

        }

        public Task<List<T>> AllAsync(bool asNoTracking)
        {
            return asNoTracking?  context.Set<T>().AsNoTracking().ToListAsync(): context.Set<T>().ToListAsync();
        }

        public Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicet)
        {
            return context.Set<T>().Where(predicet).ToListAsync();
        }

        public Task<T> FindAsync(long Id, List<string> includes = default(List<string>))
        {
            var entities = context.Set<T>();
            foreach (string include in includes)
            {
                entities.Include(include);
            }
            return entities.FindAsync(Id);
        }

        public T Find(long Id, List<string> includes = default(List<string>))
        {
            var entities = context.Set<T>();
            foreach (string include in includes)
            {
                entities.Include(include);
            }
            return entities.Find(Id);
        }

        protected ApplicationDbContext Context { get { return context as ApplicationDbContext; } }
    }
}
