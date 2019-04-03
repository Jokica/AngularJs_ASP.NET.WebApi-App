using Autofac;
using InvestMent.Application.Images;
using InvestMent.Utils.Images.GetImages;

namespace InvestMent.Utils.Images
{
    public static class ContainerConfigure
    {
        public static void Confiugre(ContainerBuilder builder)
        {
            builder.RegisterType<ProccesImage>().As<IProccesImage>();
            builder.RegisterType<GetImage>().As<IGetImage>();

        }
    }
}
