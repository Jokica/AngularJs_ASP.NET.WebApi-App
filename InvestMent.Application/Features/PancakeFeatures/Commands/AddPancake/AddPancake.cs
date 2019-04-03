using InvestMent.Application.UnitOfWork;
using InvestMent.DAL.DTOs;
using InvestMent.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace InvestMent.Application.Features.Pancakes.Commands
{
    public class AddPancakeRequest : IRequest<long>
    {
        [Required]
        public string Name { get;  set; }
        public List<IngredientsDTO> Ingredients { get; set; } = new List<IngredientsDTO>();
    }
    public class AddPancakeHandler : IRequestHandler<AddPancakeRequest,long>
    {
        private IUnitOfWork unitOfWork;
        public AddPancakeHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
      public async Task<long> Handle(AddPancakeRequest request, CancellationToken cancellationToken)
        {
            var Pancake = new Pancake {
                Name = request.Name
            };
            foreach (var ingredientDto in request.Ingredients)
            {
                Ingredient ingredient = unitOfWork.Ingridents.Find(ingredientDto.Id);
                var pancakeIngredient = new PancakeIngredients
                {
                    Pancake =Pancake,
                    Ingredient = ingredient
                };
            }
            unitOfWork.Pancakes.Add(Pancake);
            await unitOfWork.CompleteAsync();
            return Pancake.Id;
        }
    }
}
