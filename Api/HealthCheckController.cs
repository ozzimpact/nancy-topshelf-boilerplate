using Nancy;

namespace Api
{
    public class HealthCheckController:NancyModule
    {
        public HealthCheckController()
        {
            Get["/"] = parameters => HttpStatusCode.OK;
        }
    }
}