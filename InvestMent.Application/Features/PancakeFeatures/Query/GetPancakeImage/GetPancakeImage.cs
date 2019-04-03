using InvestMent.Application.Images;
using InvestMent.Application.UnitOfWork;
using MediatR;
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
        private readonly IGetImage getImage;

        public GetPancakeImageHandler(IUnitOfWork unitOfWork, IGetImage getImage)
        {
            this.unitOfWork = unitOfWork;
            this.getImage = getImage;
        }
        public async Task<GetPancakeImageResponse> Handle(GetPancakeImageRequest request, CancellationToken cancellationToken)
        {
            var Pancake = await unitOfWork.Pancakes.FindAsync(request.PancakeId);
            var img = getImage.GetImageBytes(Pancake.ImageURL);
            return new GetPancakeImageResponse
            {
                ByteImage = img
            };
        
        }
    }
}
