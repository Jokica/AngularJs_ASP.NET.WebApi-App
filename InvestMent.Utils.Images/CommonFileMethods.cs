using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InvestMent.Utils.Images
{
    public abstract class CommonFileMethods
    {
        //TODO Move to config file
        protected const int MaxLength = 1024 * 1024 * 1;
        protected const int bufferSize = 32 * 1024;

        protected virtual string GetPysicalPath()
        {
            return HttpContext.Current.Server.MapPath("~/Images");
        }
        protected virtual string GetPysicalPath(string file)
        {
            return HttpContext.Current.Server.MapPath(file);
        }
        protected virtual string GetFileExtension(string fileName)
        {
            return Path.GetExtension(fileName).ToLower();
        }
    }
}
