namespace PlanningRouteWeb.Models.V2
{
    public class TimelineORGModel : HttpResponse
    {
        public List<TimeLineOrgData> Data { get; set; } = new();
    }

    public class TimelineData : Time
    {
        public string? ROUTE_CODE { get; set; }
        public string? ORGANIZATION_CODE { get; set; }
        public string? NUM_SERVICE { get; set; }
        public string? MAX_DROP { get; set; }
    }

    public class TimelineSaleData : Time
    {
        public string? ROUTE_CODE { get; set; }
        public string? ORGANIZATION_CODE { get; set; }
        public string? SUM_REALSALE { get; set; }
        public string? SUM_AMOUNT { get; set; }
    }

    public class TimeLineOrgData : Time
    {
        public string? ORGANIZATION_CODE { get; set; }
        public string? NUM_SERVICE { get; set; }
        public string? MAX_DROP { get; set; }
    }


    public class TimeLineOrgSaleData : Time
    {
        public string? ORGANIZATION_CODE { get; set; }
        public string? SUM_REALSALE { get; set; }
        public string? SUM_AMOUNT { get; set; }
    }

    public class Time
    {
        public string? T01 {get;set;}
        public string? T02 {get;set;}
        public string? T03 {get;set;}
        public string? T04 {get;set;}
        public string? T05 {get;set;}
        public string? T06 {get;set;}
        public string? T07 {get;set;}
        public string? T08 {get;set;}
        public string? T09 {get;set;}
        public string? T10 {get;set;}
        public string? T11 {get;set;}
        public string? T12 {get;set;}
        public string? T13 {get;set;}
        public string? T14 {get;set;}
        public string? T15 {get;set;}
        public string? T16 {get;set;}
        public string? T17 {get;set;}
        public string? T18 {get;set;}
        public string? T19 {get;set;}
        public string? T20 {get;set;}
        public string? T21 {get;set;}
        public string? T22 {get;set;}
        public string? T23 {get;set;}
        public string? T24 {get;set;}
    }
}
