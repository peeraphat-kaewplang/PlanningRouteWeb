using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using PlanningRouteWeb.Helpers;
using PlanningRouteWeb.Interfaces;
using PlanningRouteWeb.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public PlanningService(IConfiguration configuration, HttpClient httpClient, StateContainer stateContainer)
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

            var res = JsonSerializer.Deserialize<RouteResponse>(content, _options);

            res!.Data = res.Data.Select(x => Models.RouteData.ConverModel(x)).ToList();
            return res;
        }
        public async Task<Tuple<columnSet, List<PlanningMasterData2>, Target2>> PlanningGetMaster(PanningMasterRequest body)
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
                            IsCurrent = DateTime.ParseExact(item.CALENDAR_DATE, "dd/MM/yyyy", null).CheckDateInCurrentWeek(_stateContainer.DateCurrent, _stateContainer.BeforeConfig),
                        });
                    }

                    var col = new Week { };

                    var mapModel = plannings?.Data.Plan
                        .Select(x =>
                        {
                            x.Week1.Add(x.MACHINE_CODE, new List<string>());
                            x.Week2.Add(x.MACHINE_CODE, new List<string>());
                            x.GETPLAN_DETAIL = x.GETPLAN_DETAIL.Select(d =>
                            {
                                var current = DateTime.ParseExact(d.CALENDAR_DATE, "dd/MM/yyyy", null).CheckDateInCurrentWeek(_stateContainer.DateCurrent, _stateContainer.BeforeConfig);
                                DateTime dateCurrent = DateTime.ParseExact(d.CALENDAR_DATE, "dd/MM/yyyy", null);
                                int week = _stateContainer.DateCurrent.GetWeekNumberOfMonth();
                                int currentWeek = dateCurrent.GetWeekNumberOfMonth();

                                if (week == currentWeek && d.STATUS_MANUAL != "Y")
                                {
                                    x.Week1[x.MACHINE_CODE].Add(d.CALENDAR_DATE);
                                }
                                else if (week + 1 == currentWeek && d.STATUS_MANUAL != "Y")
                                {
                                    x.Week2[x.MACHINE_CODE].Add(d.CALENDAR_DATE);
                                }
                                else if (week == currentWeek && d.STATUS_MANUAL == "Y"  && current)
                                {
                                    col.Week1Value = true;
                                    if (!string.IsNullOrWhiteSpace(d.RANK))
                                    {
                                        col.Week1 = true;
                                    }
                                   
                                }
                                else if (week +1 == currentWeek && d.STATUS_MANUAL == "Y" && current)
                                {
                                    col.Week2Value = true;
                                    if (!string.IsNullOrWhiteSpace(d.RANK))
                                    {
                                        col.Week2 = true;
                                    }
                                    
                                }
                                return d;
                            }).ToList();
                            return x;
                        })
                        .GroupBy(x => x.LOCATION_CODE,
                                (key, grp) =>
                                {
                                    var value = ConvertModel.PlanningMasterDataModeltoModel(grp.OrderBy(x => int.Parse(x.MSORT)).FirstOrDefault()!, _stateContainer.DateCurrent, grp, _stateContainer.BeforeConfig);
                                    return value;
                                })

                        .ToList();

                    var data = mapModel!.Select((x, idx) =>
                    {
                        var calData = new List<PlanningDetail2>();
                        foreach (var item in x.GETPLAN_DETAIL)
                        {
                            calData = CalDataPlanning.CalEstimate(item, x.GETPLAN_DETAIL);
                        }

                        x.GETPLAN_DETAIL = calData;
                        return x;
                    })
                    .OrderBy(x => x.LOCATION_CODE)
                    .ThenBy(x => int.Parse(x.MSORT))
                    .ToList();
                    return Tuple.Create(new columnSet { column = columns  , Week = col }, data, ConvertModel.TargetModelToTarget2Model(plannings!.Data.Target));
                }
                else
                {
                    return Tuple.Create(new columnSet {  }, new List<PlanningMasterData2>(), ConvertModel.TargetModelToTarget2Model(plannings!.Data.Target));
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error exception : {ex.Message.ToString()}");
            }
        }
        public async Task<List<PlanningMasterData2>> PlanningExportExcel(PanningMasterRequest body)
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

                var plannings = JsonSerializer.Deserialize<PanningMasterResponse>(content, _options);

                var data = plannings!.Data.Plan.Select(x => ConvertModel.PlanningMasterDataModeltoExcel(x, _stateContainer.DateCurrent, _stateContainer.BeforeConfig)).ToList();

                return data;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error exception : {ex.Message.ToString()}");
            }

        }
        public async Task<List<PlanningMasterData2>> PlanningGetMasterCartSystem(PlanningCartSystem body)
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

                var res = JsonSerializer.Deserialize<PanningMasterResponse>(content, _options);
                var target = res!.Data.Target;
                var plannings = res!.Data.Plan
                    .OrderBy(x => x.LOCATION_CODE)
                    .ThenBy(x => int.Parse(x.MSORT))
                    .ToList();

                int[] r1 = { 1, 1, 1, 1, 1, 1, 1 };
                int[] r2 = { 1, 1, 1, 1, 1, 1, 1 };
                var mapModel = plannings
                    .Select(x =>
                    {
                        x.Week1.Add(x.MACHINE_CODE, new List<string>());
                        x.Week2.Add(x.MACHINE_CODE, new List<string>());
                        x.GETPLAN_DETAIL = x.GETPLAN_DETAIL.Select(d =>
                        {
                            DateTime dateCurrent = DateTime.ParseExact(d.CALENDAR_DATE, "dd/MM/yyyy", null);
                            int week = _stateContainer.DateCurrent.GetWeekNumberOfMonth();
                            int currentWeek = dateCurrent.GetWeekNumberOfMonth();

                            if (week == currentWeek && d.STATUS_MANUAL != "Y")
                            {
                                x.Week1[x.MACHINE_CODE].Add(d.CALENDAR_DATE);
                            }
                            else if (week + 1 == currentWeek && d.STATUS_MANUAL != "Y")
                            {
                                x.Week2[x.MACHINE_CODE].Add(d.CALENDAR_DATE);
                            }
                            return d;
                        }).ToList();
                        return x;
                    })
                    .Select((x, idx) =>
                    {
                        x.GETPLAN_DETAIL = x.GETPLAN_DETAIL.Select(d =>
                        {
                            DateTime dateCurrent = DateTime.ParseExact(d.CALENDAR_DATE, "dd/MM/yyyy", null);
                            DateTime dateStart = DateTime.ParseExact(body.StartDate, "dd/MM/yyyy", null);
                            DateTime dateEnd = DateTime.ParseExact(body.EndDate, "dd/MM/yyyy", null);
                            //bool isCurrent = dateCurrent.CheckDateInCurrentWeek(_stateContainer.DateCurrent, _stateContainer.BeforeConfig);
                            if (d.STATUS_MANUAL == "Y" && dateCurrent >= dateStart && dateCurrent <= dateEnd)
                            {
                                var week = _stateContainer.DateCurrent.GetWeekNumberOfMonth();
                                var currentWeek = dateCurrent.GetWeekNumberOfMonth();

                                switch (SubStrDay(d.CALENDAR_DATE).FullName)
                                {
                                    case "Monday":
                                        if (currentWeek == week)
                                        {
                                            d.RANK = r1[0].ToString();
                                            r1[0] += 1;
                                        }
                                        else
                                        {
                                            d.RANK = r2[0].ToString();
                                            r2[0] += 1;
                                        }
                                        break;
                                    case "Tuesday":
                                        if (currentWeek == week)
                                        {
                                            d.RANK = r1[1].ToString();
                                            r1[1] += 1;
                                        }
                                        else
                                        {
                                            d.RANK = r2[1].ToString();
                                            r2[1] += 1;
                                        }
                                        break;
                                    case "Wednesday":
                                        if (currentWeek == week)
                                        {
                                            d.RANK = r1[2].ToString();
                                            r1[2] += 1;
                                        }
                                        else
                                        {
                                            d.RANK = r2[2].ToString();
                                            r2[2] += 1;
                                        }
                                        break;
                                    case "Thursday":
                                        if (currentWeek == week)
                                        {
                                            d.RANK = r1[3].ToString();
                                            r1[3] += 1;
                                        }
                                        else
                                        {
                                            d.RANK = r2[3].ToString();
                                            r2[3] += 1;
                                        }
                                        break;
                                    case "Friday":
                                        if (currentWeek == week)
                                        {
                                            d.RANK = r1[4].ToString();
                                            r1[4] += 1;
                                        }
                                        else
                                        {
                                            d.RANK = r2[4].ToString();
                                            r2[4] += 1;
                                        }
                                        break;
                                    case "Saturday":
                                        if (currentWeek == week)
                                        {
                                            d.RANK = r1[5].ToString();
                                            r1[5] += 1;
                                        }
                                        else
                                        {
                                            d.RANK = r2[5].ToString();
                                            r2[5] += 1;
                                        }
                                        break;
                                }
                            }
                            return d;
                        }).ToList();

                        return x;
                    })
                    .GroupBy(x => x.LOCATION_CODE,
                            (key, grp) =>
                            {
                                var value = ConvertModel.PlanningMasterDataModeltoModel(grp.OrderBy(x => int.Parse(x.MSORT)).FirstOrDefault()!, _stateContainer.DateCurrent, grp, _stateContainer.BeforeConfig);
                                return value;
                            })
                    .ToList();

                var data = mapModel!.Select((x, idx) =>
                {
                    var calData = new List<PlanningDetail2>();
                    foreach (var item in x.GETPLAN_DETAIL)
                    {
                        calData = CalDataPlanning.CalEstimate(item, x.GETPLAN_DETAIL);
                    }

                    x.GETPLAN_DETAIL = calData;
                    return x;
                })
                
                .ToList();

                return data;
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

            //var jsonstr = Newtonsoft.Json.JsonConvert.SerializeObject(contentBody);

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

            var json = JsonSerializer.Serialize(body);

            var save = JsonSerializer.Deserialize<SavePlanResponse>(content, _options);
            return save!;
        }

        public List<PlanningMasterSave> PlanningSetModelCartSystem(string start, string end, List<PlanningMasterSave> model)
        {
            int[] r1 = { 1, 1, 1, 1, 1, 1, 1 };
            int[] r2 = { 1, 1, 1, 1, 1, 1, 1 };


            var res = model
                   .Select((x, idx) =>
                   {
                       x.SAVEPLAN_detail = x.SAVEPLAN_detail.Select(d =>
                       {
                           DateTime dateCurrent = DateTime.ParseExact(d.CALENDAR_DATE, "dd/MM/yyyy", null);
                           DateTime dateStart = DateTime.ParseExact(start, "dd/MM/yyyy", null);
                           DateTime dateEnd = DateTime.ParseExact(end, "dd/MM/yyyy", null);
                           //bool isCurrent = dateCurrent.CheckDateInCurrentWeek(_stateContainer.DateCurrent, _stateContainer.BeforeConfig);
                           if (d.STATUS_MANUAL == "Y" && dateCurrent >= dateStart && dateCurrent <= dateEnd)
                           {
                               var week = _stateContainer.DateCurrent.GetWeekNumberOfMonth();
                               var currentWeek = dateCurrent.GetWeekNumberOfMonth();

                               switch (SubStrDay(d.CALENDAR_DATE).FullName)
                               {
                                   case "Monday":
                                       if (currentWeek == week)
                                       {
                                           d.RANK = r1[0].ToString();
                                           r1[0] += 1;
                                       }
                                       else
                                       {
                                           d.RANK = r2[0].ToString();
                                           r2[0] += 1;
                                       }
                                       break;
                                   case "Tuesday":
                                       if (currentWeek == week)
                                       {
                                           d.RANK = r1[1].ToString();
                                           r1[1] += 1;
                                       }
                                       else
                                       {
                                           d.RANK = r2[1].ToString();
                                           r2[1] += 1;
                                       }
                                       break;
                                   case "Wednesday":
                                       if (currentWeek == week)
                                       {
                                           d.RANK = r1[2].ToString();
                                           r1[2] += 1;
                                       }
                                       else
                                       {
                                           d.RANK = r2[2].ToString();
                                           r2[2] += 1;
                                       }
                                       break;
                                   case "Thursday":
                                       if (currentWeek == week)
                                       {
                                           d.RANK = r1[3].ToString();
                                           r1[3] += 1;
                                       }
                                       else
                                       {
                                           d.RANK = r2[3].ToString();
                                           r2[3] += 1;
                                       }
                                       break;
                                   case "Friday":
                                       if (currentWeek == week)
                                       {
                                           d.RANK = r1[4].ToString();
                                           r1[4] += 1;
                                       }
                                       else
                                       {
                                           d.RANK = r2[4].ToString();
                                           r2[4] += 1;
                                       }
                                       break;
                                   case "Saturday":
                                       if (currentWeek == week)
                                       {
                                           d.RANK = r1[5].ToString();
                                           r1[5] += 1;
                                       }
                                       else
                                       {
                                           d.RANK = r2[5].ToString();
                                           r2[5] += 1;
                                       }
                                       break;
                               }
                           }
                           return d;
                       }).ToList();

                       return x;
                   })
                   .ToList();
            return res;
        }

       
    }
}