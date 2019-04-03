using InvestMent.Application.Images;
using InvestMent.Utils.Images.Exeptions;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace InvestMent.Utils.Images
{
    public class ProccesImage :CommonFileMethods, IProccesImage
    {
        private const string UNSUPPORTED_EXEPTION_MSG = "Unsupported file extension";

        public string SavePancakeImage(HttpPostedFile postedFile, string PancakeName)
        {
            if (postedFile == null || postedFile.ContentLength == 0)
                throw new ArgumentNullException(nameof(postedFile));
            if (postedFile.ContentLength < MaxLength)
                throw new FileSizeToBigExeption();
            var extension = GetFileExtension(postedFile.FileName);
            if(!AllowedFileExtentions.Extentions.Contains(extension))
                throw new UnsupportedExtentionExeption(UNSUPPORTED_EXEPTION_MSG);
      
            var fileName = NewFileName(PancakeName, extension);
            var filePath = GetPysicalPath();
            postedFile.SaveAs(Path.Combine(filePath, fileName));
            return "~/Images/" + fileName;
        }
        public async Task<string> SavePancakeImageStream(HttpContent content,string fileName,string PancakeName)
        {
            var extensions = GetFileExtension(fileName);
            if (!AllowedFileExtentions.Extentions.Contains(extensions))
                throw new UnsupportedExtentionExeption(UNSUPPORTED_EXEPTION_MSG);

            var filePath = GetPysicalPath();
            var newFileName = NewFileName(PancakeName, extensions);
            var path = Path.Combine(filePath, newFileName);
            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize, useAsync: true))
            {
                 await content.CopyToAsync(stream);
            }
            return "~/Images/" + newFileName;
        }
        private string NewFileName(string PancakeName,string extension)
        {
            return PancakeName + DateTime.Now.ToString("yyyyMMdd_Hmmssff") + extension; 
        }
    
    }
}
