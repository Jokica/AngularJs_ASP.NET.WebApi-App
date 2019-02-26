using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> All(bool asNoTracking);
        Task<List<T>> AllAsync(bool asNoTracking);
        T Get(long Id);
        Task<T> GetAsync(long Id);
        IEnumerable<T> Find(Expression<Func<T,bool>> predicet);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicet);


        void Add(T newItem);
        void AddRange(ICollection<T> itemRange);

        bool Remove(T item);
        bool RemoveRange(ICollection<T> itemRange);
    }
}
