using Microsoft.Extensions.Configuration;
using PlanningRouteWeb.Interfaces;
using PlanningRouteWeb.Interfaces.V2;
using PlanningRouteWeb.Models;
using PlanningRouteWeb.Models.V2;
using System.Net.Http;
using System.Text.Json;

namespace PlanningRouteWeb.Services.V2
{
    public class DashboardService : IDashboardService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        private readonly IPlanningService _planningService;
        public DashboardService(IConfiguration configuration, HttpClient httpClient , IPlanningService planningService)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _planningService = planningService;
        }

        public async Task<Tuple<ErrorMessageRes, DashboardViewModel>> GetDashboardList(DashboardBody model)
        {
            var error = new ErrorMessageRes();
            var data = new DashboardViewModel();
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/REPORT_SALES_ORG"),
                    Content = JsonContent.Create(model)
                };

                var response = await _httpClient.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();

                string time = response.Headers.GetValues("X-Response-Time").FirstOrDefault()!;
                Console.WriteLine(time);

                if (!response.IsSuccessStatusCode)
                {
                    error.Error = true;
                    error.ErrorMessage = content;
                }
                else
                {
                    var org = await _planningService.PlanningGetORG(new OrganizationRequest { ORG = "" });
                    var dashboard = JsonSerializer.Deserialize<DashboardModel>(content, _options);
                    if (dashboard!.ErrorMessage == "success")
                    {
                        var d = dashboard.Data.Select(x => DashboardList.ConverModel(x, org.Data)).ToList();

                        data.Data = d;
                        data.Summary = new DashboardSummary
                        {
                            Summarys = Summary.SumModel(d),
                            Averages = Summary.SumModel(d, d.Count())
                        };
                    }
                    else
                    {
                        error.Error = true;
                        error.ErrorMessage = dashboard!.ErrorMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.ErrorMessage = ex.Message;
            }

            return Tuple.Create(error, data);
        }

        public async Task<Tuple<ErrorMessageRes, DashboardDetailViewModel>> GetDashboardDetailList(DashboardBody model)
        {
            var error = new ErrorMessageRes();
            var data = new DashboardDetailViewModel();
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/REPORT_SALES_ROUTE"),
                    Content = JsonContent.Create(model)
                };

                var response = await _httpClient.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();

                string time = response.Headers.GetValues("X-Response-Time").FirstOrDefault()!;
                Console.WriteLine(time);
                if (!response.IsSuccessStatusCode)
                {
                    error.Error = true;
                    error.ErrorMessage = content;
                }
                else
                {
                    var dashboardDetail = JsonSerializer.Deserialize<DashboardDetailModel>(content, _options);
                    if (dashboardDetail!.ErrorMessage == "success")
                    {
                        if (dashboardDetail.Data.Count() != 0)
                        {
                            var dd = dashboardDetail.Data.Select(x => DashboardDetailList.ConverModel(x)).ToList();
                            data.Data = dd;
                            data.Summary = new DashboardSummary
                            {
                                Summarys = Summary.SumDetailModel(dd),
                                Averages = Summary.SumDetailModel(dd, dd.Count())
                            };
                        }
                    }
                    else
                    {
                        error.Error = true;
                        error.ErrorMessage = dashboardDetail!.ErrorMessage;
                    }
                }
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.ErrorMessage = ex.Message;
            }

            return Tuple.Create(error, data);
        }
    }
}
