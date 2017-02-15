using System.ComponentModel;
using Topshelf;
using Topshelf.Autofac;
using IContainer = Autofac.IContainer;

namespace Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartService();
        }
        private static void StartService()
        {
            IContainer container = ContainerManager.Instance;

            HostFactory.Run(x =>
            {
                x.UseAutofacContainer(container);

                x.EnableServiceRecovery(rc =>
                {
                    rc.RestartService(1);
                    rc.OnCrashOnly();
                });

                x.Service<NancySelfHost>(s =>
                {
                    s.ConstructUsingAutofacContainer();
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.StartAutomatically();
                x.EnableShutdown();
                x.RunAsLocalService();

                x.SetDescription("NancyTopshelfBoilerplate Description");
                x.SetDisplayName("NancyTopshelfBoilerplate Display Name");
                x.SetServiceName("NancyTopshelfBoilerplate Service Name");

                x.UseNLog();

            });
        }
    }
}