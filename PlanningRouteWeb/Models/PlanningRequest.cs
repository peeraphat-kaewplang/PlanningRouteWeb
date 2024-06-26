using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlanningRouteWeb.Models
{
     public class OrganizationRequest 
    {
        public string ORG { get; set; } = string.Empty;
    }
     
    public class PanningMasterRequest
    {
        public string ORG { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public string YEARMONTH { get; set; } = string.Empty;
    }

    public class PlanningCartSystem
    {
        public string ORG { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public string YEARMONTH { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
    }

    public class SavePlanRequest: PanningMasterRequest
    {
        public List<PlanningMasterSave> Data { get; set; } = new();
    }

    public class CalPlanning : PanningMasterRequest
    {
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
    }
}