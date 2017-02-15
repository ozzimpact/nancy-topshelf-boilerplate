using Nancy.Diagnostics.Modules;
using Nancy.Testing;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public abstract class NancyControllerTestBase
    {
        protected Browser Browser;

        [SetUp]
        public void Init()
        {
            Browser = new Browser(with => with.Module(new MainModule()));
        }
    }
}
