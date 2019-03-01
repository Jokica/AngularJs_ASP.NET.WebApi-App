using InvestMent.DAL.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvestMent.Application.Features.PancakeFeatures.Query.GetPancakeImage
{
    public class GetPancakeImageRequest:IRequest<GetPancakeImageResponse>
    {
        public GetPancakeImageRequest(long pancakeId)
        {
            PancakeId = pancakeId;
        }

        public long PancakeId { get; }
    }
    public class GetPancakeImageHandler : IRequestHandler<GetPancakeImageRequest, GetPancakeImageResponse>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetPancakeImageHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<GetPancakeImageResponse> Handle(GetPancakeImageRequest request, CancellationToken cancellationToken)
        {
            var Pancake = await unitOfWork.Pancakes.FindAsync(request.PancakeId);

            var fileStream = new FileStream(Pancake.ImageURL, FileMode.Open);
            var image = Image.FromStream(fileStream);
            var stream = new MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);
            
            return new GetPancakeImageResponse
            {
                ByteImage = new ByteArrayContent(stream.ToArray())
            };
        }
    }
}
