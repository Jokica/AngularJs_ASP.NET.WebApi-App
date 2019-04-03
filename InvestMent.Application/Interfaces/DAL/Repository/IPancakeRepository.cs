



using InvestMent.Domain.Interfaces.DAL;

namespace InvestMent.Application.Repository.PancakeRepo
{
    public interface IPancakeRepository:IRepository<IDataEntity,Domain.Models.Pancake>
    {
        void AddOrUpdate(Domain.Models.Pancake pancake);
    }
}
