using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Utils.Images
{
    public static class AllowedFileExtentions
    {
        public static  List<string> Extentions { get; set; } = new List<string>
        {
                ".jpg",
                ".jpeg",
                ".png",
                ".gif"
        };
    }
}
