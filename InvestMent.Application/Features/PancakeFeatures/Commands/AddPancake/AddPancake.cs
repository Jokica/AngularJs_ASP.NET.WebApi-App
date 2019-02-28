using InvestMent.DAL.DTOs;
using InvestMent.DAL.UnitOfWork;
using InvestMent.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace InvestMent.Application.Features.Pancakes.Commands
{
    public class AddPancakeRequest : IRequest
    {
        [Required]
        public string Name { get;  set; }
        public List<IngredientsDTO> Ingredients { get; set; } = new List<IngredientsDTO>();
        public long? BrandId { get; set; }
    }
    public class AddPancakeHandler : AsyncRequestHandler<AddPancakeRequest>
    {
        private IUnitOfWork unitOfWork;
        public AddPancakeHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        protected override Task Handle(AddPancakeRequest request, CancellationToken cancellationToken)
        {
            Brand brand = request.BrandId.HasValue ? unitOfWork.Brand.Find(request.BrandId.Value) : default(Brand);
            var Pancake = new Pancake(request.Name, brand);

            foreach (var ingredientDto in request.Ingredients)
            {
                Ingredient ingredient = unitOfWork.Ingridents.Find(ingredientDto.Id);
                Pancake.AddIngredient(ingredient);
            }
            unitOfWork.Pancakes.Add(Pancake);
            return unitOfWork.CompleteAsync();
        }
    }
}
