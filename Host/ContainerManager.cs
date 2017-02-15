using Autofac;

namespace Host
{
    public static class ContainerManager
    {
        private static IContainer _container;
        private static readonly object PadLock = new object();

        public static IContainer Instance
        {
            get
            {
                if (_container == null)
                {
                    lock (PadLock)
                    {
                        if (_container == null)
                        {
                            ContainerBuilder builder = new ContainerBuilder();

                            builder.RegisterModule<HostModule>();

                            IContainer container = builder.Build();

                            _container = container;
                        }
                    }
                }

                return _container;
            }
        }
    }
}