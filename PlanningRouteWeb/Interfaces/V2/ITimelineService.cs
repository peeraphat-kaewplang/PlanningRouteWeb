using PlanningRouteWeb.Models.V2;

namespace PlanningRouteWeb.Interfaces.V2
{
    public interface ITimelineService
    {
        Task<Tuple<ErrorMessageRes, TimelineORGModel>> GetTimeLine(TimelineReq req);
        Task<Tuple<ErrorMessageRes, TimelineORGSaleModel>> GetTimeLineSale( TimelineReq req);
        Task<Tuple<ErrorMessageRes, TimelineRouteModel>> GetTimeLineRoute(TimelineReq req);
        Task<Tuple<ErrorMessageRes, TimelineRouteSaleModel>> GetTimeLineRouteSale(int numDay, TimelineReq req);
    }
}
