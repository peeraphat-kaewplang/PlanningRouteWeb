using PlanningRouteWeb.Models.V2;

namespace PlanningRouteWeb.Interfaces.V2
{
    public interface IDashboardService
    {
        Task<Tuple<ErrorMessageRes, DashboardViewModel>> GetDashboardList(DashboardBody model);
        Task<Tuple<ErrorMessageRes, DashboardDetailViewModel>> GetDashboardDetailList(DashboardBody model);
    }
}
