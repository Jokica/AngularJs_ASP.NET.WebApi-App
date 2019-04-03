using InvestMent.Application.Features.PancakeFeatures.Commands.AddPancakeImage;
using InvestMent.Application.Features.PancakeFeatures.Query.GetPancakeImage;
using InvestMent.Application.Features.Pancakes.Commands;
using InvestMent.Application.Features.Pancakes.Query.GetAll;
using InvestMent.Application.UnitOfWork;
using InvestMent.DAL.UnitOfWork;
using InvestMent.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
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


        public PancakeController(IMediator mediator, IUnitOfWork unitOfWork)
        {
            this.mediator = mediator;
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        [HttpPost]
        [Route("{Id}/AddImage")]
        public async Task  AddPanckeType(long Id)
        {
             var Image =  HttpContext.Current.Request.Files[0];
             await mediator.Send(new AddPancakeImageRequest(Image, Id));

        }

        [HttpGet]
        [Route("{Id}/GetImage")]
        public async Task<HttpResponseMessage> GetPancakeImage(long Id)
        {
            var res =  await mediator.Send(new GetPancakeImageRequest(Id));
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = res.ByteImage
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return result;

        }
        [HttpGet]
        [Route("{Id}/GetContent")]
        public async Task<HttpResponseMessage> GetPancakeContent(long Id)
        {
            Domain.Models.Pancake res = await UnitOfWork.Pancakes.FindAsync(Id);
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            var filePath = HttpContext.Current.Server.MapPath(res.ImageURL);
            result.Content =new  StreamContent(new FileStream(filePath,FileMode.Open));
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return result;

        }
        [HttpPost]
        [Route("AddPancake")]
        public async Task<long> AddPanckeType([FromBody] AddPancakeRequest request)
        {
         
            return await mediator.Send(request);
        }
        [HttpGet]
        [Route("All")]
        public async Task<List<Pancake>> GetAll( )
        {
            return await mediator.Send(new GetAllPanckesRequest());
        }
    }
}
