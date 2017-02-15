using Autofac;
using Business;

namespace Api
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HealthCheckController>().SingleInstance();
            builder.RegisterModule<BusinessModule>();
        }
    }
}