using InvestMent.Application.UnitOfWork;
using InvestMent.DAL.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace InvestMent.Application.Features.IngredientsFeatures
{
    public  class GetIngredientsNameAndIdRequest:IRequest<List<IngredientsDTO>>
    {
    }
    public class GetIngredientsNameAndIdHandler : IRequestHandler<GetIngredientsNameAndIdRequest, List<IngredientsDTO>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetIngredientsNameAndIdHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public  Task<List<IngredientsDTO>> Handle(GetIngredientsNameAndIdRequest request, CancellationToken cancellationToken)
        {
            return unitOfWork.Ingridents.GetIngredientTypeNames();
        }
    }
}
