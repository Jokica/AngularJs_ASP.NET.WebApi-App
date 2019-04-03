using InvestMent.Domain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InvestMent.Application.Repository
{
    public interface IRepository<T,U> where T : class,IDataEntity where U : class,IDomainEntity
    {
        IEnumerable<U> All(bool asNoTracking);
        Task<List<U>> AllAsync(bool asNoTracking);
        U Find(long Id);
        U Find(long Id, List<string> includes);
        Task<U> FindAsync(long Id);
        Task<U> FindAsync(long Id, List<string> includes);
        void Add(U newItem);
        void AddRange(ICollection<U> itemRange);
        bool Remove(U item);
        bool RemoveRange(ICollection<U> itemRange);
    }
}
