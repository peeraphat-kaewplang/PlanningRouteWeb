namespace PlanningRouteWeb.Models
{
    public class FormModel
    {
        public string Organization { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
    }

    public class DeatilRank
    {
        public string MACHINE_CODE { get; set; } = string.Empty;
        public int? RANK { get; set; }
        public string CALENDAR_DATE { get; set; } = string.Empty;
    }

}