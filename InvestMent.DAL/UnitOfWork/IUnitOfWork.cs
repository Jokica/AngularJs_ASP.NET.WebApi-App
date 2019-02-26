using InvestMent.DAL.Repository.BrandRepo;
using InvestMent.DAL.Repository.IngredientsRepo;
using InvestMent.DAL.Repository.PancakeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.DAL.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IPancakeRepository Pancakes { get; }
        IBrandRepository Brand { get; }
        IIngredientRepository Ingridents { get; }
        int Complete();
        Task<int> CompleteAsync();

    }
}
