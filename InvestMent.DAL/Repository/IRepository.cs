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
        T Find(long Id, List<string> includes = default(List<string>));
        Task<T> FindAsync(long Id, List<string> includes = default(List<string>));
        IEnumerable<T> Where(Expression<Func<T,bool>> predicet);
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> predicet);


        void Add(T newItem);
        void AddRange(ICollection<T> itemRange);

        bool Remove(T item);
        bool RemoveRange(ICollection<T> itemRange);
    }
}
