using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.DAL.Exeptions
{
    class InvalidDomainEntity:Exception
    {
        public InvalidDomainEntity():base($"{nameof(InvalidDomainEntity)}")
        {

        }
    }
}
