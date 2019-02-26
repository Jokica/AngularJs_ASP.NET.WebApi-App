using InvestMent.Domain.Models;
using InvestMent.Persistence;

namespace InvestMent.DAL.Repository.PancakeRepo
{
    public class PancakeRepository:RepositoryBase<Pancake>,IPancakeRepository
    {
        public PancakeRepository(ApplicationDbContext context)
            :base(context)
        {

        }
    }
}
