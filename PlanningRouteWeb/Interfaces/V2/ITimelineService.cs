using PlanningRouteWeb.Models.V2;

namespace PlanningRouteWeb.Interfaces.V2
{
    public interface ITimelineService
    {
        Task<Tuple<ErrorMessageRes, List<TimeLineOrgData>>> GetTimeLine();
    }
}
