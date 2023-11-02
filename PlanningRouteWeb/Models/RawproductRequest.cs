namespace PlanningRouteWeb.Models
{
    public class RawproductRequest
    {
        public string RawProductCode { get; set; } = string.Empty;
        public string ORG { get; set; } = string.Empty;
    }

    public class RawproductDetail2Request
    {
        public string RawProductCode { get; set; } = string.Empty;
        public string ORG { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Machine { get; set; } = string.Empty;
    }
}
