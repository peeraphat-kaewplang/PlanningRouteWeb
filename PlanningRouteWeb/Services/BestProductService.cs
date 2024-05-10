using PlanningRouteWeb.Interfaces;
using PlanningRouteWeb.Models;
using System.Text.Json;

namespace PlanningRouteWeb.Services
{
    public class BestProductService : IBestProduct
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        public BestProductService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<BestProductResponse> GetBestProduct(BestProductRequest body)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}/V1/GETBESTPRODUCT"),
                Content = JsonContent.Create(body)
            };

            var response = await _httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var res = JsonSerializer.Deserialize<BestProductResponse>(content, _options);


            return res!;
        }
    }
}
