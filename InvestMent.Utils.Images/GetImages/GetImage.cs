using System.IO;
using System.Net.Http;
using System.Drawing;
using System.Drawing.Imaging;
using InvestMent.Application.Images;

namespace InvestMent.Utils.Images.GetImages
{
    public class GetImage : CommonFileMethods,IGetImage
    {

        public ByteArrayContent GetImageBytes(string ImageUrl)
        {
            var filePath = GetPysicalPath(ImageUrl);
            //var fileStream = new FileStream(filePath, FileMode.Open);

            using (var image = Image.FromFile(filePath))
            using (var stream = new MemoryStream())
            {
                var extension = GetFileExtension(ImageUrl);
                var isPng = extension == ".png";
                ImageFormat format = isPng ? ImageFormat.Png : ImageFormat.Jpeg;
                image.Save(stream, format);
                return new ByteArrayContent(stream.ToArray());
            };
          
        }

        public StreamContent GetImageStream(string ImageUrl)
        {
            var filePath = GetPysicalPath(ImageUrl);
            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, useAsync: true);
            return new StreamContent(stream);
        }
    }
}
