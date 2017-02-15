using Api;
using Autofac;
using NLog;

namespace Host
{
    public class HostModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NancySelfHost>().SingleInstance();
            builder.RegisterInstance(LogManager.GetLogger("Logger")).As<ILogger>();
            builder.RegisterModule<ApiModule>();
        }
    }
}