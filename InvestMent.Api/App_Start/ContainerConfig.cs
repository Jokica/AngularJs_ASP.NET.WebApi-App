using Autofac;
using Autofac.Features.Variance;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using InvestMent.Application.Features.Pancakes.Query.GetAll;
using MediatR;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace InvestMent.Api
{
    public static class ContainerConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            //Application Layer
            //Application.ContainerConfigure.Configure(builder);
            Utils.Images.ContainerConfigure.Confiugre(builder);
            DAL.ContainerConfigure.Confiugre(builder);
            //Register API Controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            //Register MVC Controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //Mediator
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();



            builder.RegisterAssemblyTypes(typeof(GetAllPanckesRequest).GetTypeInfo().Assembly).Where(t =>
                   t.GetInterfaces().Any(i => i.IsClosedTypeOf(typeof(IRequestHandler<,>))
                                           || i.IsClosedTypeOf(typeof(AsyncRequestHandler<>))
                                           || i.IsClosedTypeOf(typeof(INotificationHandler<>))
                                        )
                )
                .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            //Lazy Container
            var lazyContainer = new Lazy<IContainer>(()=>builder.Build());
            config.DependencyResolver = new AutofacWebApiDependencyResolver(lazyContainer.Value);
        }
    }

}
