using System.Globalization;
using System.Reflection;
using System.Text.Json;
using PlanningRouteWeb.Helpers;
using PlanningRouteWeb.Interfaces;
using PlanningRouteWeb.Models;

namespace PlanningRouteWeb.Services
{
    public class PlanningService : IPlanningService
    {
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly StateContainer _stateContainer;

        public IDictionary<string, ColumnProperty> columns { get; set; } = new Dictionary<string, ColumnProperty>();
        public IEnumerable<IDictionary<string, object>> data { get; set; } = new List<Dictionary<string, object>>() { };
        public PlanningService(IConfiguration configuration, HttpClient httpClient , StateContainer stateContainer)
        {
            _httpClient = httpClient;
            _stateContainer = stateContainer;
            _configuration = configuration;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<OrganizationResponse?> PlanningGetORG(OrganizationRequest org)
        {
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/GETORG"),
                    Content = JsonContent.Create(org)
                };

                var response = await _httpClient.SendAsync(requestMessage);

                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }

                var organizations = JsonSerializer.Deserialize<OrganizationResponse>(content, _options);
                return organizations;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error exception : {ex.Message.ToString()}");
            }
        }

        public async Task<RouteResponse?> PlanningGetRoute(OrganizationRequest org)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/GETROUTE"),
                Content = JsonContent.Create(org)
            };

            var response = await _httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var organizations = JsonSerializer.Deserialize<RouteResponse>(content, _options);
            return organizations;
        }
        public async Task<Tuple<IDictionary<string, ColumnProperty>, List<PlanningMasterData2> , Target>> PlanningGetMaster(PanningMasterRequest body)
        {
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/GETPLAN"),
                    Content = JsonContent.Create(body)
                };
                var response = await _httpClient.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException($"Http error : {content}");
                }

                //_stateContainer.BeforeConfig = 1;

                var plannings = JsonSerializer.Deserialize<PanningMasterResponse>(content, _options);
                var dataPlan = plannings!.Data.Plan.Where(p => p.GETPLAN_DETAIL.Count() > 30).ToList();

                var aaa = dataPlan.Where(x => x.MACHINE_CODE == "28936").ToList();

                if (dataPlan.Count() != 0)
                {
                    columns = new Dictionary<string, ColumnProperty>();
                    foreach (var (item, index) in dataPlan[0].GETPLAN_DETAIL.WithIndex())
                    {
                        string[] day = item.CALENDAR_DATE.Split('/');
                        columns.Add(item.CALENDAR_DATE,
                        new ColumnProperty
                        {
                            FieldDate = day[0],
                            FieldDateName = SubStrDay(item.CALENDAR_DATE).Name,
                            FieldRankName = "Seq",
                            FieldValueName = "Value",
                            ClassColor = SubStrDay(item.CALENDAR_DATE).FullName.ToLower(),
                            IsCurrent = DateTime.ParseExact(item.CALENDAR_DATE, "dd/MM/yyyy", null).CheckDateInCurrentWeek(1 + _stateContainer.BeforeConfig),
                        });
                    }

                    var mapModel = plannings?.Data.Plan
                        //.Where(x => x.LOCATION_CODE == "0163915")
                        .GroupBy(x =>  x.LOCATION_CODE , 
                                (key, grp) => 
                                ConvertModel.PlanningMasterDataModeltoModel(grp.OrderBy(x => int.Parse(x.MSORT)).FirstOrDefault()! , _stateContainer.BeforeConfig , grp))
                        .OrderBy(x => x.LOCATION_CODE)
                        .ThenBy(x => int.Parse(x.MSORT))
                        .ToList();

                    var data = mapModel!.Select(x =>
                    {
                        var calData = new List<PlanningDetail2>();
                        foreach (var item in x.GETPLAN_DETAIL)
                        {
                            calData = CalDataPlanning.CalEstimate(item, x.GETPLAN_DETAIL);
                        }

                        x.GETPLAN_DETAIL = calData;
                        return x;
                    })
                    //.Skip(0).Take(1)
                    .ToList();
                    return Tuple.Create(columns, data, plannings!.Data.Target);
                }
                else
                {
                    return Tuple.Create(columns, new List<PlanningMasterData2>(), new Target());
                }
                
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error exception : {ex.Message.ToString()}");
            }
        }
        public async Task<SavePlanResponse> PlanningSavePlan(List<PlanningMasterSave> body)
        {
            var contentBody = new SavePlanRequest
            {
                YEARMONTH = body[0].YEARMONTH,
                ORG = body[0].ORGANIZATION_CODE,
                Route = body[0].ROUTE_CODE,
                Data = body
            };
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/SAVEPLAN"),
                Content = JsonContent.Create(contentBody)
            };

            var response = await _httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var save = JsonSerializer.Deserialize<SavePlanResponse>(content, _options);
            return save!;
        }

        public async Task<SavePlanResponse> PlanningSaveTarget(TargetSave body)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/SAVETARGET"),
                Content = JsonContent.Create(body)

            };

            var response = await _httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var save = JsonSerializer.Deserialize<SavePlanResponse>(content, _options);
            return save!;
        }

        public DayObject SubStrDay(string date)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date.StringToDateTime("dd/MM/yyyy"));
            var dayName = GetDatetimeClass.defultday.SingleOrDefault(d => d.FullName == day.ToString());
            return dayName!;
        }

        public object GetObjectByName(object val, string name)
        {
            Type type = val.GetType();
            PropertyInfo propertyInfo = type?.GetProperty(name)!;

            if (
                name == "MONDAY" ||
                name == "TUESDAY" ||
                name == "WEDNESDAY" ||
                name == "THURSDAY" ||
                name == "FRIDAY" ||
                name == "SATURDAY" ||
                name == "SUNDAY"
            )
            {
                return string.IsNullOrWhiteSpace(propertyInfo?.GetValue(val, null)!.ToString()) ? false : true;
            }
            return propertyInfo?.GetValue(val, null)!;
        }

        public async Task<SavePlanResponse> PlanningCalPlan(CalPlanning body)
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("POST"),
                RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}API_PLANNING/V1/CALPLAN"),
                Content = JsonContent.Create(body)

            };

            var response = await _httpClient.SendAsync(requestMessage);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var save = JsonSerializer.Deserialize<SavePlanResponse>(content, _options);
            return save!;
        }
    }
}