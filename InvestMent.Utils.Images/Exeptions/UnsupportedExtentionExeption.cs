using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Utils.Images.Exeptions
{
    class UnsupportedExtentionExeption:Exception
    {
        public UnsupportedExtentionExeption(string msg):base(msg)
        {

        }
    }
}
