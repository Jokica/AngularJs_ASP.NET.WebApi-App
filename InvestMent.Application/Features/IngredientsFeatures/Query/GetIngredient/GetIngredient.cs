using InvestMent.DAL.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvestMent.Application.Features.IngredientsFeatures.Query.GetIngredient
{
    public class GetIngredientRequest:IRequest<GetIngredientResponse>
    {
        public GetIngredientRequest(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }

    public class GetIngredientHandler : IRequestHandler<GetIngredientRequest, GetIngredientResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetIngredientHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<GetIngredientResponse> Handle(GetIngredientRequest request, CancellationToken cancellationToken)
        {
            var includes = new List<string>
            {
                "Type",
                "IngredientBrand"

            };
            var Ingredient = await unitOfWork.Ingridents.FindAsync(request.Id,includes);
            return new GetIngredientResponse
            {
                Id = Ingredient.Id,
                Name = Ingredient.Name,
                Type = Ingredient.Type.Name,
                IngredientBrand = Ingredient.IngredientBrand.Name
            };
        }
    }
    public class GetIngredientResponse
    {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string IngredientBrand { get; set; }
}
}
