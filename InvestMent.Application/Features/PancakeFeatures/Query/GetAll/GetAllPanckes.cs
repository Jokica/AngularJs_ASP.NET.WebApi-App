using InvestMent.DAL.UnitOfWork;
using InvestMent.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvestMent.Application.Features.Pancakes.Query.GetAll
{
    public class GetAllPanckesRequest : IRequest<List<Pancake>>
    {
    }

    public class GetAllPancakesHandler : IRequestHandler<GetAllPanckesRequest, List<Pancake>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllPancakesHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<List<Pancake>> Handle(GetAllPanckesRequest request, CancellationToken cancellationToken)
        {
            return unitOfWork.Pancakes.AllAsync(false);
        }
    }
    public class GetallPanckesResponse
    {
        public string Name { get; internal set; }
    }
}
