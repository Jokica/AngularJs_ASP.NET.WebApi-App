using Autofac;
using InvestMent.Application.UnitOfWork;
using InvestMent.Persistence.DBFirstApproach;

namespace InvestMent.DAL
{
    public static class ContainerConfigure
    {
        public static void Confiugre(ContainerBuilder builder)
        {
            builder.RegisterType<DbFirstContext>().AsSelf();
            builder.RegisterType<UnitOfWork.UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
