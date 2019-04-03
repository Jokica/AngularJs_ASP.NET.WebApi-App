using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace InvestMent.Application.Images
{
    public interface IProccesImage
    {
        string SavePancakeImage(HttpPostedFile postedFile, string PancakeName);
        Task<string> SavePancakeImageStream(HttpContent content, string filename, string pancakName);
    }
}
