using System.Net.Http;

namespace InvestMent.Application.Images
{
    public interface IGetImage
    {
        ByteArrayContent GetImageBytes(string ImageUrl);
        StreamContent GetImageStream(string ImageUrl);

    }
}
