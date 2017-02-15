using Autofac;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Autofac;
using NLog;

namespace Host
{
    public class CustomBootstrapper : AutofacNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(ILifetimeScope container)
        {
            container.Update(builder => builder.RegisterModule<HostModule>());
        }
        protected override void RequestStartup(ILifetimeScope container, IPipelines pipelines, NancyContext context)
        {
            ILogger logger = container.Resolve<ILogger>();

            pipelines.OnError.AddItemToEndOfPipeline((z, a) =>
            {
                logger.Error("Unhandled error on request: " + context.Request.Url + " : " + a.Message);

                return ErrorResponse.FromException(a);
            });

            base.RequestStartup(container, pipelines, context);
        }
    }
}