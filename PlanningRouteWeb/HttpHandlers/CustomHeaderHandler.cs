namespace PlanningRouteWeb.HttpHandlers
{
    public class CustomHeaderHandler : DelegatingHandler
    {
        private readonly IConfiguration Configuration;
        public CustomHeaderHandler(IConfiguration configuration) : base(new HttpClientHandler()) {
            Configuration = configuration;
         }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Authorization" , Configuration.GetValue<string>("Configs:AuthToken"));
            request.Headers.Add("X-SUN-API-KEY" , Configuration.GetValue<string>("Configs:ApiKey"));
            return base.SendAsync(request, cancellationToken);
        }
    }
}