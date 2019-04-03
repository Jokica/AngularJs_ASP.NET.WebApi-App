using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Domain.Interfaces.DAL
{
    public interface IDataEntity
    {
        IDomainEntity Convert();
    }
}
