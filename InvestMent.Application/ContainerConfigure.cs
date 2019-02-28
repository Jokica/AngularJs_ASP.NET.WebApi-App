using Autofac;
using InvestMent.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.Application
{
    public static class ContainerConfigure
    {
        public static void Configure(ContainerBuilder builder)
        {
            DAL.ContainerConfigure.Confiugre(builder);
        }
    }
}
