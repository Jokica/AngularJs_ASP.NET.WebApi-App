using InvestMent.Application.UnitOfWork;
using MediatR;
using System.Collections.Generic;
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
            Domain.Models.Ingredient ingredient = await unitOfWork.Ingridents.FindAsync(request.Id,includes);
            return new GetIngredientResponse
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                Type = ingredient.Type.Name,
                IngredientBrand = ingredient.IngredientBrand.Name
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
