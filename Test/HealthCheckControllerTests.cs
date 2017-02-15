using FluentAssertions;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;

namespace Test
{
    public class HealthCheckControllerTests : NancyControllerTestBase
    {
        [Test]
        public void healtcheck_should_return_200()
        {

            BrowserResponse result = Browser.Get("/", context =>
            {
                context.HttpRequest();
            });

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void not_registered_controller_should_return_404()
        {
            BrowserResponse result = Browser.Get("/notfound", context =>
            {
                context.HttpRequest();
            });

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}