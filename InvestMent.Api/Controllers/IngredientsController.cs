using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using InvestMent.Application.Features.IngredientsFeatures;
using InvestMent.DAL.DTOs;
using InvestMent.Domain.Models;
using InvestMent.Persistence;
using MediatR;

namespace InvestMent.Api.Controllers
{
    public class IngredientsController : ApiController
    {
        private readonly IMediator mediator;

        public IngredientsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/Ingredients
        public async Task<List<IngredientsDTO>> GetIngredientNames()
        {
            return await mediator.Send(new GetIngredientsNameAndIdRequest());
        }
    }
}
