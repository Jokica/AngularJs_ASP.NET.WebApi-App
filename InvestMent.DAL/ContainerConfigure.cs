using Autofac;
using InvestMent.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestMent.DAL
{
    public static class ContainerConfigure
    {
        public static void Confiugre(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf();
            builder.RegisterType<UnitOfWork.UnitOfWork>().As<UnitOfWork.IUnitOfWork>();
        }
    }
}
