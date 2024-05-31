using PlanningRouteWeb.Models.V2;

namespace PlanningRouteWeb.Interfaces.V2
{
    public interface ITimelineService
    {
        Task<Tuple<ErrorMessageRes, TimelineModel>> GetTimeLine(TimelineReq req);
        Task<Tuple<ErrorMessageRes, List<TimelineMechineData1>>> GetTimeLineMechine(TimelineMechineReq req);
        //Task<Tuple<ErrorMessageRes, TimelineORGSaleModel>> GetTimeLineSale(int numDay, TimelineReq req);
        //Task<Tuple<ErrorMessageRes, TimelineRouteModel>> GetTimeLineRoute(TimelineReq req);
        //Task<Tuple<ErrorMessageRes, TimelineRouteSaleModel>> GetTimeLineRouteSale(int numDay, TimelineReq req);
    }
}
