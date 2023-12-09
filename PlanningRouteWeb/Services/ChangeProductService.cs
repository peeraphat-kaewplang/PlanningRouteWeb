using Microsoft.Extensions.Configuration;
using PlanningRouteWeb.Helpers;
using PlanningRouteWeb.Interfaces;
using PlanningRouteWeb.Models;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace PlanningRouteWeb.Services
{
    public class ChangeProductService : IChangeProductService
    {
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public ChangeProductService(IConfiguration configuration, HttpClient httpClient, StateContainer stateContainer)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<ChangeProductData2> GetChangeProduct(ChangeProductRequest body)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/GETCHANGEPRODUCT"),
                Content = JsonContent.Create(body)
            };

            var response = await _httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var changeProduct = JsonSerializer.Deserialize<ChangeProductResponse>(content, _options);

            //var aa = changeProduct!.Data.Detail.OrderBy(x => x.SLOT_NO).ToList();

            //var json = JsonSerializer.Serialize(aa);


            var data = new ChangeProductData2
            {
                Header = changeProduct!.Data.Header,
                Detail = changeProduct!.Data.Detail
                .Select(x =>
                {
                    var chagePrd = changeProduct!.Data.Detail.Find(d => d.SLOT_NO == x.SLOT_NO && d.STATUSCHANGE != x.STATUSCHANGE);
                    if (chagePrd != null)
                    {
                        return ConvertModel.ChangeProductDetailModal(x, true);
                    }
                    return ConvertModel.ChangeProductDetailModal(x);
                })
                .OrderBy(x => x.SLOT_NO)
                .ThenBy(x => x.STATUSCHANGE)
                .ToList()
            };

            //var data = new ChangeProductData2
            //{
            //    Header = changeProduct!.Data.Header,
            //    Detail = changeProduct!.Data.Detail
            //    .Select(x =>
            //    {
            //        return ConvertModel.ChangeProductDetailModal(x , x.STATUSCHANGE == "0" ? false : true);
            //    })
            //    .OrderBy(x => x.SLOT_NO)
            //    .ThenBy(x => x.STATUSCHANGE)
            //    .ToList()
            //};


            return data;
        }

        public async Task<RawproductResponse> GetRawproduct(RawproductRequest body)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/GETRAWPRODUCT"),
                Content = JsonContent.Create(body)
            };

            var response = await _httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var product = JsonSerializer.Deserialize<RawproductResponse>(content, _options);

            return product!;
        }

        public async Task<RawproductDetailResponse> GetRawproductDetail(RawproductRequest body)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/GETRAWPRODUCTDT"),
                Content = JsonContent.Create(body)
            };

            var response = await _httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var productDetail = JsonSerializer.Deserialize<RawproductDetailResponse>(content, _options);

           
            return productDetail!;
        }

        public async Task<RawproductDetail2Response> GetRawproductDetail2(RawproductDetail2Request body)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/GETRAWPRODUCTDT2"),
                Content = JsonContent.Create(body)
            };

            var response = await _httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var productDetail = JsonSerializer.Deserialize<RawproductDetail2Response>(content, _options);


            return productDetail!;
        }

        public async Task<SaveChangeProductResponse> SaveChangeProduct(SaveChangeProductRequest body)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/SAVECHANGEPRODUCT"),
                Content = JsonContent.Create(body)
            };

            var response = await _httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var res = JsonSerializer.Deserialize<SaveChangeProductResponse>(content, _options);


            return res!;
        }
    }
}
