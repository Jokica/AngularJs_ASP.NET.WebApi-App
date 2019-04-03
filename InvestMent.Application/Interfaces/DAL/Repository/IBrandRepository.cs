

using InvestMent.Domain.Interfaces.DAL;

namespace InvestMent.Application.Repository.BrandRepo
{
    public interface IBrandRepository:IRepository<IDataEntity, Domain.Models.Brand> 
    {
        void AddOrUpdate(Domain.Models.Brand brand);
    }
}
