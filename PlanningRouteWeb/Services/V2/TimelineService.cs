using PlanningRouteWeb.Helpers;
using PlanningRouteWeb.Interfaces;
using PlanningRouteWeb.Interfaces.V2;
using PlanningRouteWeb.Models.V2;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlanningRouteWeb.Services.V2;

public class TimelineService : ITimelineService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;

    public TimelineService(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
    public async Task<Tuple<ErrorMessageRes, TimelineModel>> GetTimeLine(TimelineReq req)
    {
        var error = new ErrorMessageRes();
        var data = new TimelineModel();
        try
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/REPORT_TIMELINE"),
                Content = JsonContent.Create(req)
            };

            var response = await _httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                error.Error = true;
                error.ErrorMessage = content;
            }

            var res = JsonSerializer.Deserialize<TimelineModelRes>(content, _options);

            res!.Data = res!.Data.Select(x =>
            {
                x.ProgressDrop = TimeLineData.ConverModelProgressDrop(x);
                x.ProgressSale = TimeLineData.ConverModelProgressSale(x);
                return x;
            }).ToList();
            data.Data.TimelineList = res!.Data;
            data.Data.TimeLineSum = new TimeLineData
            {
                MAX_DROP = res!.Data.Sum(x => x.MAX_DROP),
                SUM_AMOUT = res!.Data.Sum(x => x.SUM_AMOUT),
                SUM_REALSALE = res!.Data.Sum(x => x.SUM_REALSALE),
                ProgressDrop = res.Data.Sum(x => x.ProgressDrop),
                ProgressSale = res.Data.Sum(x => x.ProgressSale),
                T01_DROP = res.Data.Sum(x => x.T01_DROP),
                T02_DROP = res.Data.Sum(x => x.T02_DROP),
                T03_DROP = res.Data.Sum(x => x.T03_DROP),
                T04_DROP = res.Data.Sum(x => x.T04_DROP),
                T05_DROP = res.Data.Sum(x => x.T05_DROP),
                T06_DROP = res.Data.Sum(x => x.T06_DROP),
                T07_DROP = res.Data.Sum(x => x.T07_DROP),
                T08_DROP = res.Data.Sum(x => x.T08_DROP),
                T09_DROP = res.Data.Sum(x => x.T09_DROP),
                T10_DROP = res.Data.Sum(x => x.T10_DROP),
                T11_DROP = res.Data.Sum(x => x.T11_DROP),
                T12_DROP = res.Data.Sum(x => x.T12_DROP),
                T13_DROP = res.Data.Sum(x => x.T13_DROP),
                T14_DROP = res.Data.Sum(x => x.T14_DROP),
                T15_DROP = res.Data.Sum(x => x.T15_DROP),
                T16_DROP = res.Data.Sum(x => x.T16_DROP),
                T17_DROP = res.Data.Sum(x => x.T17_DROP),
                T18_DROP = res.Data.Sum(x => x.T18_DROP),
                T19_DROP = res.Data.Sum(x => x.T19_DROP),
                T20_DROP = res.Data.Sum(x => x.T20_DROP),
                T21_DROP = res.Data.Sum(x => x.T21_DROP),
                T22_DROP = res.Data.Sum(x => x.T22_DROP),
                T23_DROP = res.Data.Sum(x => x.T23_DROP),
                T00_DROP = res.Data.Sum(x => x.T00_DROP),
                T01_SALE = res.Data.Sum(x => x.T01_SALE),
                T02_SALE = res.Data.Sum(x => x.T02_SALE),
                T03_SALE = res.Data.Sum(x => x.T03_SALE),
                T04_SALE = res.Data.Sum(x => x.T04_SALE),
                T05_SALE = res.Data.Sum(x => x.T05_SALE),
                T06_SALE = res.Data.Sum(x => x.T06_SALE),
                T07_SALE = res.Data.Sum(x => x.T07_SALE),
                T08_SALE = res.Data.Sum(x => x.T08_SALE),
                T09_SALE = res.Data.Sum(x => x.T09_SALE),
                T10_SALE = res.Data.Sum(x => x.T10_SALE),
                T11_SALE = res.Data.Sum(x => x.T11_SALE),
                T12_SALE = res.Data.Sum(x => x.T12_SALE),
                T13_SALE = res.Data.Sum(x => x.T13_SALE),
                T14_SALE = res.Data.Sum(x => x.T14_SALE),
                T15_SALE = res.Data.Sum(x => x.T15_SALE),
                T16_SALE = res.Data.Sum(x => x.T16_SALE),
                T17_SALE = res.Data.Sum(x => x.T17_SALE),
                T18_SALE = res.Data.Sum(x => x.T18_SALE),
                T19_SALE = res.Data.Sum(x => x.T19_SALE),
                T20_SALE = res.Data.Sum(x => x.T20_SALE),
                T21_SALE = res.Data.Sum(x => x.T21_SALE),
                T22_SALE = res.Data.Sum(x => x.T22_SALE),
                T23_SALE = res.Data.Sum(x => x.T23_SALE),
                T00_SALE = res.Data.Sum(x => x.T00_SALE),
            };
        }
        catch (Exception ex)
        {
            error.Error = true;
            error.ErrorMessage = ex.Message;
        }

        return Tuple.Create(error, data);
    }
}
