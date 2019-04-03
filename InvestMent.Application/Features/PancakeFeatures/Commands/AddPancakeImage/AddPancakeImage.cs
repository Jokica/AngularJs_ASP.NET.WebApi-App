using InvestMent.Application.Images;
using InvestMent.Application.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace InvestMent.Application.Features.PancakeFeatures.Commands.AddPancakeImage
{
    public class AddPancakeImageRequest : IRequest
    {
        public HttpPostedFile PostedFile { get; }
        public long Id { get;  set; }
        public AddPancakeImageRequest(HttpPostedFile postedFile,long id)
        {
            PostedFile = postedFile;
            Id = id;
        }
    }
    public class AddPancakeImageHandler : AsyncRequestHandler<AddPancakeImageRequest>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IProccesImage proccesImage;

        public AddPancakeImageHandler(IUnitOfWork unitOfWork, IProccesImage proccesImage)
        {
            this.unitOfWork = unitOfWork;
            this.proccesImage = proccesImage;
        }
        protected  override  Task Handle(AddPancakeImageRequest request, CancellationToken cancellationToken)
        {
            var pancake = unitOfWork.Pancakes.Find(request.Id);
            pancake.ImageURL = proccesImage.SavePancakeImage(request.PostedFile, pancake.Name);
            return unitOfWork.CompleteAsync();
        }
    }
}
