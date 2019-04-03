using InvestMent.Application.Repository.BrandRepo;
using InvestMent.Application.Repository.IngredientsRepo;
using InvestMent.Application.Repository.PancakeRepo;
using System;
using System.Threading.Tasks;

namespace InvestMent.Application.UnitOfWork
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
