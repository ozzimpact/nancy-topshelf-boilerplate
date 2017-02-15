using System;
using Nancy.Hosting.Self;
using NLog;

namespace Host
{
    public class NancySelfHost
    {
        private readonly ILogger _logger;
        private NancyHost _mNancyHost;

        public NancySelfHost(ILogger logger)
        {
            _logger = logger;
        }
        public void Start()
        {
            const string endPoint = "http://localhost:1000";

            _mNancyHost = new NancyHost(new Uri(endPoint));
            _mNancyHost.Start();


            _logger.Info("NancyTopshelfBoilerplate started.");
        }

        public void Stop()
        {
            _mNancyHost.Stop();
            _logger.Info("NancyTopshelfBoilerplate stopped.");
        }
    }
}