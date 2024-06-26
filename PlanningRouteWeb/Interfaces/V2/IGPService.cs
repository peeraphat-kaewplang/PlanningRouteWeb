using PlanningRouteWeb.Models.V2;

namespace PlanningRouteWeb.Interfaces.V2
{
    public interface IGPService
    {
        Task<Tuple<ErrorMessageRes, List<ChangeProductDetailView>, List<GPModelDataView>, ChangeProductHeader>> GetGPByProduct(ParameterChangeProduct body);
    }
}
