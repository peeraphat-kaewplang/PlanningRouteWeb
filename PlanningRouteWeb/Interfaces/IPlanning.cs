using PlanningRouteWeb.Models;

namespace PlanningRouteWeb.Interfaces
{
    public interface IPlanningService
    {
        Task<OrganizationResponse?> PlanningGetORG(OrganizationRequest org);
        Task<RouteResponse?> PlanningGetRoute(OrganizationRequest org);
        Task<Tuple<columnSet, List<PlanningMasterData2>, Target2>> PlanningGetMaster(PanningMasterRequest body);
        Task<List<PlanningMasterData2>> PlanningExportExcel(PanningMasterRequest body);
        Task<List<PlanningMasterData2>> PlanningGetMasterCartSystem(PlanningCartSystem body);
        List<PlanningMasterSave> PlanningSetModelCartSystem(string start, string end, List<PlanningMasterSave> model);
        Task<SavePlanResponse> PlanningSavePlan(List<PlanningMasterSave> body);
        Task<SavePlanResponse> PlanningCalPlan(CalPlanning body);
        Task<SavePlanResponse> PlanningSaveTarget(TargetSave body);
        Task<Target2> PlanningGetTarget(PanningMasterRequest body);

        Task<ProductLowQty> PlanningGetProductLowQty(string mc);

    }
}