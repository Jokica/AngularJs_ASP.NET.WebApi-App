using InvestMent.Domain.Interfaces.DAL;

namespace InvestMent.Persistence.DBFirstApproach
{
    public partial class Brand : IDataEntity
    {
        public IDomainEntity Convert()
        {
            return new Domain.Models.Brand(this.Name,this.Id);
        }
    }
}
