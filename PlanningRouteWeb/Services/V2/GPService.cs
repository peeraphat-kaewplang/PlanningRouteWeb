using PlanningRouteWeb.Interfaces.V2;
using PlanningRouteWeb.Models;
using PlanningRouteWeb.Models.V2;
using System.Text.Json;

namespace PlanningRouteWeb.Services.V2
{
    public class GPService : IGPService
    {
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public GPService(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<Tuple<ErrorMessageRes, List<ChangeProductDetailView>, List<GPModelDataView>, Models.V2.ChangeProductHeader>> GetGPByProduct(ParameterChangeProduct body)
        {
            var error = new ErrorMessageRes();
            var dataGP = new List<GPModelDataView>();
            var dataPrd = new List<ChangeProductDetailView>();
            var header = new Models.V2.ChangeProductHeader { };
            try
            {
                var requestMessage = new HttpRequestMessage()
                {
                    Method = new HttpMethod("POST"),
                    RequestUri = new Uri($"{_configuration.GetValue<string>("Configs:UrlApi")}/V1/GETNEWCHANGEPRODUCT"),
                    Content = JsonContent.Create(body)
                };

                var response = await _httpClient.SendAsync(requestMessage);
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    error.Error = true;
                    error.ErrorMessage = content;
                    return Tuple.Create(error, dataPrd, dataGP , header);
                }

                var res = JsonSerializer.Deserialize<ChangeProductRes>(content, _options);

                dataGP = res!.Data.GP.Select(g => GPModelDataView.ConvertModel(g)).ToList();

                dataPrd = res!.Data.Detail
                .Select(model => {
                    var sCost = dataGP.Find(d => d.PRODUCT_CODE.Equals(model.PRODUCT_CODE));
                    if (sCost != null)
                        model.S_COSTPRICE = sCost.S_COSTPRICE;
                    return ChangeProductDetailView.ConverModel(model);
                })
                .OrderBy(o => o.SLOT_NO)
                .ToList();

                header = res!.Data.Header;
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.ErrorMessage = ex.Message;
            }

            return Tuple.Create(error, dataPrd, dataGP , header);
        }
    }
}


