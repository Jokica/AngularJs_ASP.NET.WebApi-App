using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Domain.Models
{
    public class Brand
    {
        public Brand()
        {

        }
        public Brand(string name)
        {
            Name = name;
        }
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
