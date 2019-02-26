using InvestMent.Domain.Models;
using InvestMent.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.DAL.Repository.BrandRepo
{
    public class BrandRepository:RepositoryBase<Brand>,IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
