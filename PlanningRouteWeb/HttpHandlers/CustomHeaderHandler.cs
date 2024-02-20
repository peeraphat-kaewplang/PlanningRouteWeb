using System.Diagnostics;

namespace PlanningRouteWeb.HttpHandlers
{
    public class CustomHeaderHandler : DelegatingHandler
    {
        private readonly IConfiguration Configuration;
        public CustomHeaderHandler(IConfiguration configuration) : base(new HttpClientHandler()) {
            Configuration = configuration;
         }

        async protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var watch = new Stopwatch();
            watch.Start();
            request.Headers.Add("Authorization", Configuration.GetValue<string>("Configs:AuthToken"));
            request.Headers.Add("X-SUN-API-KEY", Configuration.GetValue<string>("Configs:ApiKey"));
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            watch.Stop();
            var responseTimeForCompleteRequest = watch.Elapsed;
            response.Headers.Add("X-Response-Time", responseTimeForCompleteRequest.ToString());
            return response;
        }
    }
}