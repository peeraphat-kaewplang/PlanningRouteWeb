using PlanningRouteWeb.Models;

namespace PlanningRouteWeb.Interfaces
{
    public interface IPlanningService
    {
        Task<OrganizationResponse?> PlanningGetORG(OrganizationRequest org);
        Task<RouteResponse?> PlanningGetRoute(OrganizationRequest org);
        Task<Tuple<IDictionary<string, ColumnProperty>, List<PlanningMasterData2>, Target>> PlanningGetMaster(PanningMasterRequest body);
        Task<SavePlanResponse> PlanningSavePlan(List<PlanningMasterSave> body);
        Task<SavePlanResponse> PlanningCalPlan(CalPlanning body);
        Task<SavePlanResponse> PlanningSaveTarget(TargetSave body);
    }
}