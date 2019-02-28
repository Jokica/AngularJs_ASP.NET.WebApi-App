using InvestMent.Application.Features.Pancakes.Commands;
using InvestMent.Application.Features.Pancakes.Query.GetAll;
using InvestMent.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace InvestMent.Api.Controllers
{

    [RoutePrefix("api/Pancake")]
    public class PancakeController : ApiController
    {
        private readonly IMediator mediator;
        public PancakeController()
        {

        }


        public PancakeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        [Route("AddPancake")]
        public async Task AddPanckeType([FromBody] AddPancakeRequest request)
        {
            if(request != null)
             await mediator.Send(request);
        }
        [HttpGet]
        [Route("All")]
        public async Task<List<Pancake>> GetAll( )
        {

            return await mediator.Send(new GetAllPanckesRequest());
        }
    }
}
