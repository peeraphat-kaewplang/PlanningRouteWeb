using PlanningRouteWeb.Helpers;
using PlanningRouteWeb.Interfaces;
using PlanningRouteWeb.Interfaces.V2;
using PlanningRouteWeb.Models.V2;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlanningRouteWeb.Services.V2
{
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
        public async Task<Tuple<ErrorMessageRes, TimelineORGModel>> GetTimeLine(TimelineReq req)
        {
            var error = new ErrorMessageRes();
            var data = new TimelineORGModel();
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/REPORT_DROP_SERVICE"),
                    Content = JsonContent.Create(req)
                };

                var response = await _httpClient.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    error.Error = true;
                    error.ErrorMessage = content;
                }

                var res = JsonSerializer.Deserialize<TimelineORGModelRes>(content, _options);

                res!.Data = res!.Data.Select(x =>
                {
                    x.Progress = TimeLineOrgData.ConverModel(x);
                    return x;
                }).ToList();

                data.Data.TimeLineSum = new TimeLineOrgSumData
                {
                    SUM_DROP = res!.Data.Sum(x => int.Parse(x.MAX_DROP!)).ToString(),
                    SUM_SERVICE = res!.Data.Sum(x => int.Parse(x.NUM_SERVICE!)).ToString(),
                    Progress = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.Progress) ? 0 : int.Parse(x.Progress)).ToStringNumberFormat(false),
                    T01 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T01) ? 0 : int.Parse(x.T01!)).ToString(),
                    T02 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T02) ? 0 : int.Parse(x.T02!)).ToString(),
                    T03 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T03) ? 0 : int.Parse(x.T03!)).ToString(),
                    T04 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T04) ? 0 : int.Parse(x.T04!)).ToString(),
                    T05 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T05) ? 0 : int.Parse(x.T05!)).ToString(),
                    T06 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T06) ? 0 : int.Parse(x.T06!)).ToString(),
                    T07 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T07) ? 0 : int.Parse(x.T07!)).ToString(),
                    T08 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T08) ? 0 : int.Parse(x.T08!)).ToString(),
                    T09 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T09) ? 0 : int.Parse(x.T09!)).ToString(),
                    T10 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T10) ? 0 : int.Parse(x.T10!)).ToString(),
                    T11 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T11) ? 0 : int.Parse(x.T11!)).ToString(),
                    T12 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T12) ? 0 : int.Parse(x.T12!)).ToString(),
                    T13 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T13) ? 0 : int.Parse(x.T13!)).ToString(),
                    T14 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T14) ? 0 : int.Parse(x.T14!)).ToString(),
                    T15 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T15) ? 0 : int.Parse(x.T15!)).ToString(),
                    T16 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T16) ? 0 : int.Parse(x.T16!)).ToString(),
                    T17 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T17) ? 0 : int.Parse(x.T17!)).ToString(),
                    T18 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T18) ? 0 : int.Parse(x.T18!)).ToString(),
                    T19 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T19) ? 0 : int.Parse(x.T19!)).ToString(),
                    T20 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T20) ? 0 : int.Parse(x.T20!)).ToString(),
                    T21 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T21) ? 0 : int.Parse(x.T21!)).ToString(),
                    T22 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T22) ? 0 : int.Parse(x.T22!)).ToString(),
                    T23 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T23) ? 0 : int.Parse(x.T23!)).ToString(),
                    T00 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T00) ? 0 : int.Parse(x.T00!)).ToString(),
                };

                data.Data.TimelineList = res!.Data.Select(x =>
                {
                    x.MAX_DROP = string.IsNullOrWhiteSpace(x.MAX_DROP) ? "0" : x.MAX_DROP;
                    x.NUM_SERVICE = string.IsNullOrWhiteSpace(x.NUM_SERVICE) ? "0" : x.NUM_SERVICE;
                    x.Progress = TimeLineOrgData.ConverModel(x).ToStringNumberFormat(false);
                    x.T01 = string.IsNullOrWhiteSpace(x.T01) ? "0" : x.T01;
                    x.T02 = string.IsNullOrWhiteSpace(x.T02) ? "0" : x.T02;
                    x.T03 = string.IsNullOrWhiteSpace(x.T03) ? "0" : x.T03;
                    x.T04 = string.IsNullOrWhiteSpace(x.T04) ? "0" : x.T04;
                    x.T05 = string.IsNullOrWhiteSpace(x.T05) ? "0" : x.T05;
                    x.T06 = string.IsNullOrWhiteSpace(x.T06) ? "0" : x.T06;
                    x.T07 = string.IsNullOrWhiteSpace(x.T07) ? "0" : x.T07;
                    x.T08 = string.IsNullOrWhiteSpace(x.T08) ? "0" : x.T08;
                    x.T09 = string.IsNullOrWhiteSpace(x.T09) ? "0" : x.T09;
                    x.T10 = string.IsNullOrWhiteSpace(x.T10) ? "0" : x.T10;
                    x.T11 = string.IsNullOrWhiteSpace(x.T11) ? "0" : x.T11;
                    x.T12 = string.IsNullOrWhiteSpace(x.T12) ? "0" : x.T12;
                    x.T13 = string.IsNullOrWhiteSpace(x.T13) ? "0" : x.T13;
                    x.T14 = string.IsNullOrWhiteSpace(x.T14) ? "0" : x.T14;
                    x.T15 = string.IsNullOrWhiteSpace(x.T15) ? "0" : x.T15;
                    x.T16 = string.IsNullOrWhiteSpace(x.T16) ? "0" : x.T16;
                    x.T17 = string.IsNullOrWhiteSpace(x.T17) ? "0" : x.T17;
                    x.T18 = string.IsNullOrWhiteSpace(x.T18) ? "0" : x.T18;
                    x.T19 = string.IsNullOrWhiteSpace(x.T19) ? "0" : x.T19;
                    x.T20 = string.IsNullOrWhiteSpace(x.T20) ? "0" : x.T20;
                    x.T21 = string.IsNullOrWhiteSpace(x.T21) ? "0" : x.T21;
                    x.T22 = string.IsNullOrWhiteSpace(x.T22) ? "0" : x.T22;
                    x.T23 = string.IsNullOrWhiteSpace(x.T23) ? "0" : x.T23;
                    x.T00 = string.IsNullOrWhiteSpace(x.T00) ? "0" : x.T00;
                    return x;
                }).ToList();
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.ErrorMessage = ex.Message;
            }

            return Tuple.Create(error, data);
        }

        public async Task<Tuple<ErrorMessageRes, TimelineORGSaleModel>> GetTimeLineSale( TimelineReq req)
        {
            var error = new ErrorMessageRes();
            var data = new TimelineORGSaleModel();
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/REPORT_DROP_REALSALE"),
                    Content = JsonContent.Create(req )

                };

                var response = await _httpClient.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    error.Error = true;
                    error.ErrorMessage = content;
                }

                var res = JsonSerializer.Deserialize<TimelineORGSaleModelRes>(content, _options);

                res!.Data = res!.Data.Select(x =>
                {
                    x.Progress = TimeLineOrgSaleData.ConverModel(x);
                    return x;
                }).ToList();


                data.Data.TimeLineSum = new TimeLineOrgSumData
                {
                    SUM_DROP = res!.Data.Sum(x => string.IsNullOrWhiteSpace(x.SUM_AMOUT) ? double.Parse("0") : double.Parse(x.SUM_AMOUT)).ToStringNumberFormat(false),
                    SUM_SERVICE = res!.Data.Sum(x => string.IsNullOrWhiteSpace(x.SUM_REALSALE) ? double.Parse("0") : double.Parse(x.SUM_REALSALE)).ToStringNumberFormat(false),
                    Progress = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.Progress) ? 0 : int.Parse(x.Progress)).ToStringNumberFormat(false),
                    T01 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T01) ? 0 : int.Parse(x.T01)).ToStringNumberFormat(),
                    T02 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T02) ? 0 : int.Parse(x.T02)).ToStringNumberFormat(),
                    T03 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T03) ? 0 : int.Parse(x.T03)).ToStringNumberFormat(),
                    T04 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T04) ? 0 : int.Parse(x.T04)).ToStringNumberFormat(),
                    T05 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T05) ? 0 : int.Parse(x.T05)).ToStringNumberFormat(),
                    T06 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T06) ? 0 : int.Parse(x.T06)).ToStringNumberFormat(),
                    T07 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T07) ? 0 : int.Parse(x.T07)).ToStringNumberFormat(),
                    T08 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T08) ? 0 : int.Parse(x.T08)).ToStringNumberFormat(),
                    T09 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T09) ? 0 : int.Parse(x.T09)).ToStringNumberFormat(),
                    T10 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T10) ? 0 : int.Parse(x.T10)).ToStringNumberFormat(),
                    T11 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T11) ? 0 : int.Parse(x.T11)).ToStringNumberFormat(),
                    T12 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T12) ? 0 : int.Parse(x.T12)).ToStringNumberFormat(),
                    T13 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T13) ? 0 : int.Parse(x.T13)).ToStringNumberFormat(),
                    T14 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T14) ? 0 : int.Parse(x.T14)).ToStringNumberFormat(),
                    T15 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T15) ? 0 : int.Parse(x.T15)).ToStringNumberFormat(),
                    T16 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T16) ? 0 : int.Parse(x.T16)).ToStringNumberFormat(),
                    T17 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T17) ? 0 : int.Parse(x.T17)).ToStringNumberFormat(),
                    T18 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T18) ? 0 : int.Parse(x.T18)).ToStringNumberFormat(),
                    T19 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T19) ? 0 : int.Parse(x.T19)).ToStringNumberFormat(),
                    T20 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T20) ? 0 : int.Parse(x.T20)).ToStringNumberFormat(),
                    T21 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T21) ? 0 : int.Parse(x.T21)).ToStringNumberFormat(),
                    T22 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T22) ? 0 : int.Parse(x.T22)).ToStringNumberFormat(),
                    T23 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T23) ? 0 : int.Parse(x.T23)).ToStringNumberFormat(),
                    T00 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T00) ? 0 : int.Parse(x.T00)).ToStringNumberFormat(),
                };

                data.Data.TimelineSaleList = res!.Data.Select(x =>
                {
                    //x.SUM_AMOUNT = string.IsNullOrWhiteSpace(x.SUM_AMOUT) ? "0" : double.Parse(x.SUM_AMOUT).ToStringNumberFormat(false);
                    //x.SUM_REALSALE = string.IsNullOrWhiteSpace(x.SUM_REALSALE) ? "0" : double.Parse(x.SUM_REALSALE).ToStringNumberFormat(false);
                    x.Progress = TimeLineOrgSaleData.ConverModel(x).ToStringNumberFormat(false);
                    x.T01 = string.IsNullOrWhiteSpace(x.T01) ? "0" : x.T01.ToStringNumberFormat();
                    x.T02 = string.IsNullOrWhiteSpace(x.T02) ? "0" : x.T02.ToStringNumberFormat();
                    x.T03 = string.IsNullOrWhiteSpace(x.T03) ? "0" : x.T03.ToStringNumberFormat();
                    x.T04 = string.IsNullOrWhiteSpace(x.T04) ? "0" : x.T04.ToStringNumberFormat();
                    x.T05 = string.IsNullOrWhiteSpace(x.T05) ? "0" : x.T05.ToStringNumberFormat();
                    x.T06 = string.IsNullOrWhiteSpace(x.T06) ? "0" : x.T06.ToStringNumberFormat();
                    x.T07 = string.IsNullOrWhiteSpace(x.T07) ? "0" : x.T07.ToStringNumberFormat();
                    x.T08 = string.IsNullOrWhiteSpace(x.T08) ? "0" : x.T08.ToStringNumberFormat();
                    x.T09 = string.IsNullOrWhiteSpace(x.T09) ? "0" : x.T09.ToStringNumberFormat();
                    x.T10 = string.IsNullOrWhiteSpace(x.T10) ? "0" : x.T10.ToStringNumberFormat();
                    x.T11 = string.IsNullOrWhiteSpace(x.T11) ? "0" : x.T11.ToStringNumberFormat();
                    x.T12 = string.IsNullOrWhiteSpace(x.T12) ? "0" : x.T12.ToStringNumberFormat();
                    x.T13 = string.IsNullOrWhiteSpace(x.T13) ? "0" : x.T13.ToStringNumberFormat();
                    x.T14 = string.IsNullOrWhiteSpace(x.T14) ? "0" : x.T14.ToStringNumberFormat();
                    x.T15 = string.IsNullOrWhiteSpace(x.T15) ? "0" : x.T15.ToStringNumberFormat();
                    x.T16 = string.IsNullOrWhiteSpace(x.T16) ? "0" : x.T16.ToStringNumberFormat();
                    x.T17 = string.IsNullOrWhiteSpace(x.T17) ? "0" : x.T17.ToStringNumberFormat();
                    x.T18 = string.IsNullOrWhiteSpace(x.T18) ? "0" : x.T18.ToStringNumberFormat();
                    x.T19 = string.IsNullOrWhiteSpace(x.T19) ? "0" : x.T19.ToStringNumberFormat();
                    x.T20 = string.IsNullOrWhiteSpace(x.T20) ? "0" : x.T20.ToStringNumberFormat();
                    x.T21 = string.IsNullOrWhiteSpace(x.T21) ? "0" : x.T21.ToStringNumberFormat();
                    x.T22 = string.IsNullOrWhiteSpace(x.T22) ? "0" : x.T22.ToStringNumberFormat();
                    x.T23 = string.IsNullOrWhiteSpace(x.T23) ? "0" : x.T23.ToStringNumberFormat();
                    x.T00 = string.IsNullOrWhiteSpace(x.T00) ? "0" : x.T00.ToStringNumberFormat();
                    return x;
                }).ToList();

            }
            catch (Exception ex)
            {
                error.Error = true;
                error.ErrorMessage = ex.Message;
            }
            return Tuple.Create(error, data);
        }

        public async Task<Tuple<ErrorMessageRes, TimelineRouteModel>> GetTimeLineRoute(TimelineReq req)
        {
            var error = new ErrorMessageRes();
            var data = new TimelineRouteModel();
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/REPORT_DROP_SERVICE"),
                    Content = JsonContent.Create(req)
                };

                var response = await _httpClient.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    error.Error = true;
                    error.ErrorMessage = content;
                }

                var res = JsonSerializer.Deserialize<TimelineRouteModelRes>(content, _options);


                res!.Data = res!.Data.Select(x =>
                {
                    x.Progress = TimelineData.ConverModel(x);
                    return x;
                }).ToList();


                data.Data.TimeLineSum = new TimeLineOrgSumData
                {
                    SUM_DROP = res.Data.Sum(x => int.Parse(x.MAX_DROP!)).ToString(),
                    SUM_SERVICE = res.Data.Sum(x => int.Parse(x.NUM_SERVICE!)).ToString(),
                    Progress = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.Progress) ? 0 : int.Parse(x.Progress)).ToStringNumberFormat(false),
                    T01 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T01) ? 0 : int.Parse(x.T01!)).ToString(),
                    T02 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T02) ? 0 : int.Parse(x.T02!)).ToString(),
                    T03 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T03) ? 0 : int.Parse(x.T03!)).ToString(),
                    T04 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T04) ? 0 : int.Parse(x.T04!)).ToString(),
                    T05 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T05) ? 0 : int.Parse(x.T05!)).ToString(),
                    T06 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T06) ? 0 : int.Parse(x.T06!)).ToString(),
                    T07 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T07) ? 0 : int.Parse(x.T07!)).ToString(),
                    T08 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T08) ? 0 : int.Parse(x.T08!)).ToString(),
                    T09 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T09) ? 0 : int.Parse(x.T09!)).ToString(),
                    T10 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T10) ? 0 : int.Parse(x.T10!)).ToString(),
                    T11 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T11) ? 0 : int.Parse(x.T11!)).ToString(),
                    T12 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T12) ? 0 : int.Parse(x.T12!)).ToString(),
                    T13 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T13) ? 0 : int.Parse(x.T13!)).ToString(),
                    T14 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T14) ? 0 : int.Parse(x.T14!)).ToString(),
                    T15 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T15) ? 0 : int.Parse(x.T15!)).ToString(),
                    T16 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T16) ? 0 : int.Parse(x.T16!)).ToString(),
                    T17 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T17) ? 0 : int.Parse(x.T17!)).ToString(),
                    T18 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T18) ? 0 : int.Parse(x.T18!)).ToString(),
                    T19 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T19) ? 0 : int.Parse(x.T19!)).ToString(),
                    T20 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T20) ? 0 : int.Parse(x.T20!)).ToString(),
                    T21 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T21) ? 0 : int.Parse(x.T21!)).ToString(),
                    T22 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T22) ? 0 : int.Parse(x.T22!)).ToString(),
                    T23 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T23) ? 0 : int.Parse(x.T23!)).ToString(),
                    T00 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T00) ? 0 : int.Parse(x.T00!)).ToString(),
                };

                data.Data.TimelineListRoute = res!.Data.Select(x =>
                {
                    x.MAX_DROP = string.IsNullOrWhiteSpace(x.MAX_DROP) ? "0" : x.MAX_DROP;
                    x.NUM_SERVICE = string.IsNullOrWhiteSpace(x.NUM_SERVICE) ? "0" : x.NUM_SERVICE;
                    x.Progress = TimelineData.ConverModel(x).ToStringNumberFormat(false);
                    x.T01 = string.IsNullOrWhiteSpace(x.T01) ? "0" : x.T01;
                    x.T02 = string.IsNullOrWhiteSpace(x.T02) ? "0" : x.T02;
                    x.T03 = string.IsNullOrWhiteSpace(x.T03) ? "0" : x.T03;
                    x.T04 = string.IsNullOrWhiteSpace(x.T04) ? "0" : x.T04;
                    x.T05 = string.IsNullOrWhiteSpace(x.T05) ? "0" : x.T05;
                    x.T06 = string.IsNullOrWhiteSpace(x.T06) ? "0" : x.T06;
                    x.T07 = string.IsNullOrWhiteSpace(x.T07) ? "0" : x.T07;
                    x.T08 = string.IsNullOrWhiteSpace(x.T08) ? "0" : x.T08;
                    x.T09 = string.IsNullOrWhiteSpace(x.T09) ? "0" : x.T09;
                    x.T10 = string.IsNullOrWhiteSpace(x.T10) ? "0" : x.T10;
                    x.T11 = string.IsNullOrWhiteSpace(x.T11) ? "0" : x.T11;
                    x.T12 = string.IsNullOrWhiteSpace(x.T12) ? "0" : x.T12;
                    x.T13 = string.IsNullOrWhiteSpace(x.T13) ? "0" : x.T13;
                    x.T14 = string.IsNullOrWhiteSpace(x.T14) ? "0" : x.T14;
                    x.T15 = string.IsNullOrWhiteSpace(x.T15) ? "0" : x.T15;
                    x.T16 = string.IsNullOrWhiteSpace(x.T16) ? "0" : x.T16;
                    x.T17 = string.IsNullOrWhiteSpace(x.T17) ? "0" : x.T17;
                    x.T18 = string.IsNullOrWhiteSpace(x.T18) ? "0" : x.T18;
                    x.T19 = string.IsNullOrWhiteSpace(x.T19) ? "0" : x.T19;
                    x.T20 = string.IsNullOrWhiteSpace(x.T20) ? "0" : x.T20;
                    x.T21 = string.IsNullOrWhiteSpace(x.T21) ? "0" : x.T21;
                    x.T22 = string.IsNullOrWhiteSpace(x.T22) ? "0" : x.T22;
                    x.T23 = string.IsNullOrWhiteSpace(x.T23) ? "0" : x.T23;
                    x.T00 = string.IsNullOrWhiteSpace(x.T00) ? "0" : x.T00;
                    return x;
                }).ToList();
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.ErrorMessage = ex.Message;
            }

            return Tuple.Create(error, data);
        }

        public async Task<Tuple<ErrorMessageRes, TimelineRouteSaleModel>> GetTimeLineRouteSale(int numDay, TimelineReq req)
        {
            var error = new ErrorMessageRes();
            var data = new TimelineRouteSaleModel();
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/REPORT_DROP_REALSALE"),
                    Content = JsonContent.Create(req)

                };

                var response = await _httpClient.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    error.Error = true;
                    error.ErrorMessage = content;
                }

                var res = JsonSerializer.Deserialize<TimelineRouteSaleModelRes>(content, _options);

                res!.Data = res!.Data.Select(x =>
                {
                    x.Progress = TimelineSaleData.ConverModel(x);
                    return x;
                }).ToList();


                data.Data.TimeLineSum = new TimeLineOrgSumData
                {
                    SUM_DROP = res!.Data.Sum(x => string.IsNullOrWhiteSpace(x.SUM_AMOUT) ? double.Parse("0") : double.Parse(x.SUM_AMOUT)).ToStringNumberFormat(false),
                    //SUM_SERVICE = res!.Data.Sum(x => string.IsNullOrWhiteSpace(x.SUM_REALSALE) ? double.Parse("0") : double.Parse(x.SUM_REALSALE)).ToStringNumberFormat(false),
                    Progress = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.Progress) ? 0 : int.Parse(x.Progress)).ToStringNumberFormat(false),
                    T01 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T01) ? 0 : int.Parse(x.T01!)).ToStringNumberFormat(),
                    T02 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T02) ? 0 : int.Parse(x.T02!)).ToStringNumberFormat(),
                    T03 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T03) ? 0 : int.Parse(x.T03!)).ToStringNumberFormat(),
                    T04 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T04) ? 0 : int.Parse(x.T04!)).ToStringNumberFormat(),
                    T05 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T05) ? 0 : int.Parse(x.T05!)).ToStringNumberFormat(),
                    T06 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T06) ? 0 : int.Parse(x.T06!)).ToStringNumberFormat(),
                    T07 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T07) ? 0 : int.Parse(x.T07!)).ToStringNumberFormat(),
                    T08 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T08) ? 0 : int.Parse(x.T08!)).ToStringNumberFormat(),
                    T09 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T09) ? 0 : int.Parse(x.T09!)).ToStringNumberFormat(),
                    T10 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T10) ? 0 : int.Parse(x.T10!)).ToStringNumberFormat(),
                    T11 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T11) ? 0 : int.Parse(x.T11!)).ToStringNumberFormat(),
                    T12 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T12) ? 0 : int.Parse(x.T12!)).ToStringNumberFormat(),
                    T13 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T13) ? 0 : int.Parse(x.T13!)).ToStringNumberFormat(),
                    T14 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T14) ? 0 : int.Parse(x.T14!)).ToStringNumberFormat(),
                    T15 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T15) ? 0 : int.Parse(x.T15!)).ToStringNumberFormat(),
                    T16 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T16) ? 0 : int.Parse(x.T16!)).ToStringNumberFormat(),
                    T17 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T17) ? 0 : int.Parse(x.T17!)).ToStringNumberFormat(),
                    T18 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T18) ? 0 : int.Parse(x.T18!)).ToStringNumberFormat(),
                    T19 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T19) ? 0 : int.Parse(x.T19!)).ToStringNumberFormat(),
                    T20 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T20) ? 0 : int.Parse(x.T20!)).ToStringNumberFormat(),
                    T21 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T21) ? 0 : int.Parse(x.T21!)).ToStringNumberFormat(),
                    T22 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T22) ? 0 : int.Parse(x.T22!)).ToStringNumberFormat(),
                    T23 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T23) ? 0 : int.Parse(x.T23!)).ToStringNumberFormat(),
                    T00 = res.Data.Sum(x => string.IsNullOrWhiteSpace(x.T00) ? 0 : int.Parse(x.T00!)).ToStringNumberFormat(),
                };

                data.Data.TimelineListRouteSale = res!.Data.Select(x =>
                {
                    x.SUM_AMOUT = (int.Parse(x.SUM_AMOUT!)*numDay).ToStringNumberFormat(false);
                    x.Progress = TimelineSaleData.ConverModel(x).ToStringNumberFormat(false);
                    x.T01 = string.IsNullOrWhiteSpace(x.T01) ? "0" : x.T01.ToStringNumberFormat();
                    x.T02 = string.IsNullOrWhiteSpace(x.T02) ? "0" : x.T02.ToStringNumberFormat();
                    x.T03 = string.IsNullOrWhiteSpace(x.T03) ? "0" : x.T03.ToStringNumberFormat();
                    x.T04 = string.IsNullOrWhiteSpace(x.T04) ? "0" : x.T04.ToStringNumberFormat();
                    x.T05 = string.IsNullOrWhiteSpace(x.T05) ? "0" : x.T05.ToStringNumberFormat();
                    x.T06 = string.IsNullOrWhiteSpace(x.T06) ? "0" : x.T06.ToStringNumberFormat();
                    x.T07 = string.IsNullOrWhiteSpace(x.T07) ? "0" : x.T07.ToStringNumberFormat();
                    x.T08 = string.IsNullOrWhiteSpace(x.T08) ? "0" : x.T08.ToStringNumberFormat();
                    x.T09 = string.IsNullOrWhiteSpace(x.T09) ? "0" : x.T09.ToStringNumberFormat();
                    x.T10 = string.IsNullOrWhiteSpace(x.T10) ? "0" : x.T10.ToStringNumberFormat();
                    x.T11 = string.IsNullOrWhiteSpace(x.T11) ? "0" : x.T11.ToStringNumberFormat();
                    x.T12 = string.IsNullOrWhiteSpace(x.T12) ? "0" : x.T12.ToStringNumberFormat();
                    x.T13 = string.IsNullOrWhiteSpace(x.T13) ? "0" : x.T13.ToStringNumberFormat();
                    x.T14 = string.IsNullOrWhiteSpace(x.T14) ? "0" : x.T14.ToStringNumberFormat();
                    x.T15 = string.IsNullOrWhiteSpace(x.T15) ? "0" : x.T15.ToStringNumberFormat();
                    x.T16 = string.IsNullOrWhiteSpace(x.T16) ? "0" : x.T16.ToStringNumberFormat();
                    x.T17 = string.IsNullOrWhiteSpace(x.T17) ? "0" : x.T17.ToStringNumberFormat();
                    x.T18 = string.IsNullOrWhiteSpace(x.T18) ? "0" : x.T18.ToStringNumberFormat();
                    x.T19 = string.IsNullOrWhiteSpace(x.T19) ? "0" : x.T19.ToStringNumberFormat();
                    x.T20 = string.IsNullOrWhiteSpace(x.T20) ? "0" : x.T20.ToStringNumberFormat();
                    x.T21 = string.IsNullOrWhiteSpace(x.T21) ? "0" : x.T21.ToStringNumberFormat();
                    x.T22 = string.IsNullOrWhiteSpace(x.T22) ? "0" : x.T22.ToStringNumberFormat();
                    x.T23 = string.IsNullOrWhiteSpace(x.T23) ? "0" : x.T23.ToStringNumberFormat();
                    x.T00 = string.IsNullOrWhiteSpace(x.T00) ? "0" : x.T00.ToStringNumberFormat();
                    return x;
                }).ToList();
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
