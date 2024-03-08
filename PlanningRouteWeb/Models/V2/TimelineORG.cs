namespace PlanningRouteWeb.Models.V2
{
    public class TimelineORGModelRes : HttpResponse
    {
        public List<TimeLineOrgData> Data { get; set; } = new();
    }

    public class TimelineReq
    {
        public string? ORG { get; set; }
        public string? ROUTE { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? ReportShow { get; set; }
    }

    public class TimelineORGModel : HttpResponse
    {
        public ResultTimelineOrg Data { get; set; } = new();
    }

    public class TimelineORGSaleModelRes : HttpResponse
    {
        public List<TimeLineOrgSaleData> Data {  get; set; } = new();
    }

    public class TimelineORGSaleModel : HttpResponse
    {
        public ResultTimelineSaleOrg Data { get; set; } = new();
    }


    public class TimelineRouteModelRes : HttpResponse
    {
        public List<TimelineData> Data { get; set;} = new();
    }

    public class TimelineRouteModel : HttpResponse
    {
        public ResultTimelineRoute Data { get; set; } = new();
    }

    public class TimelineRouteSaleModelRes : HttpResponse
    {
        public List<TimelineSaleData> Data { get; set; } = new();
    }

    public class TimelineRouteSaleModel : HttpResponse
    {
        public ResultTimelineRouteSale Data { get; set; } = new();
    }

    public class ResultTimelineOrg
    {
        public List<TimeLineOrgData> TimelineList { get; set; } = new();
        public TimeLineOrgSumData TimeLineSum { get; set; } = new();
    }

    public class ResultTimelineSaleOrg
    {
        public List<TimeLineOrgSaleData> TimelineSaleList { get; set; } = new();
        public TimeLineOrgSumData TimeLineSum { get; set; } = new();
    }
    public class ResultTimelineRoute
    {
        public List<TimelineData> TimelineListRoute { get; set; } = new();
        public TimeLineOrgSumData TimeLineSum { get; set; } = new();
    }

    public class ResultTimelineRouteSale
    {
        public List<TimelineSaleData> TimelineListRouteSale { get; set; } = new();
        public TimeLineOrgSumData TimeLineSum { get; set; } = new();
    }

    public class TimelineData : Time
    {
        public string? ROUTE_CODE { get; set; }
        public string? ORGANIZATION_CODE { get; set; }
        public string? NUM_SERVICE { get; set; }
        public string? MAX_DROP { get; set; }
        public string? Progress { get; set; }
        public static string ConverModel(TimelineData model)
        {
            var val = (
                 (string.IsNullOrWhiteSpace(model.T00) ? 0 : double.Parse(model.T00)) +
                 (string.IsNullOrWhiteSpace(model.T01) ? 0 : double.Parse(model.T01)) +
                 (string.IsNullOrWhiteSpace(model.T02) ? 0 : double.Parse(model.T02)) +
                 (string.IsNullOrWhiteSpace(model.T03) ? 0 : double.Parse(model.T03)) +
                 (string.IsNullOrWhiteSpace(model.T04) ? 0 : double.Parse(model.T04)) +
                 (string.IsNullOrWhiteSpace(model.T05) ? 0 : double.Parse(model.T05)) +
                 (string.IsNullOrWhiteSpace(model.T06) ? 0 : double.Parse(model.T06)) +
                 (string.IsNullOrWhiteSpace(model.T07) ? 0 : double.Parse(model.T07)) +
                 (string.IsNullOrWhiteSpace(model.T08) ? 0 : double.Parse(model.T08)) +
                 (string.IsNullOrWhiteSpace(model.T09) ? 0 : double.Parse(model.T09)) +
                 (string.IsNullOrWhiteSpace(model.T10) ? 0 : double.Parse(model.T10)) +
                 (string.IsNullOrWhiteSpace(model.T11) ? 0 : double.Parse(model.T11)) +
                 (string.IsNullOrWhiteSpace(model.T12) ? 0 : double.Parse(model.T12)) +
                 (string.IsNullOrWhiteSpace(model.T13) ? 0 : double.Parse(model.T13)) +
                 (string.IsNullOrWhiteSpace(model.T14) ? 0 : double.Parse(model.T14)) +
                 (string.IsNullOrWhiteSpace(model.T15) ? 0 : double.Parse(model.T15)) +
                 (string.IsNullOrWhiteSpace(model.T16) ? 0 : double.Parse(model.T16)) +
                 (string.IsNullOrWhiteSpace(model.T17) ? 0 : double.Parse(model.T17)) +
                 (string.IsNullOrWhiteSpace(model.T18) ? 0 : double.Parse(model.T18)) +
                 (string.IsNullOrWhiteSpace(model.T19) ? 0 : double.Parse(model.T19)) +
                 (string.IsNullOrWhiteSpace(model.T20) ? 0 : double.Parse(model.T20)) +
                 (string.IsNullOrWhiteSpace(model.T21) ? 0 : double.Parse(model.T21)) +
                 (string.IsNullOrWhiteSpace(model.T22) ? 0 : double.Parse(model.T22)) +
                 (string.IsNullOrWhiteSpace(model.T23) ? 0 : double.Parse(model.T23))
                 ).ToString();
            return val;
        }
    }

    public class TimelineSaleData : Time
    {
        public string? ROUTE_CODE { get; set; }
        public string? ORGANIZATION_CODE { get; set; }
        public string? SUM_REALSALE { get; set; }
        public string? SUM_AMOUT { get; set; }
        public string? Progress { get; set; }
        public static string ConverModel(TimelineSaleData model)
        {
            var val = (
                 (string.IsNullOrWhiteSpace(model.T00) ? 0 : double.Parse(model.T00)) +
                 (string.IsNullOrWhiteSpace(model.T01) ? 0 : double.Parse(model.T01)) +
                 (string.IsNullOrWhiteSpace(model.T02) ? 0 : double.Parse(model.T02)) +
                 (string.IsNullOrWhiteSpace(model.T03) ? 0 : double.Parse(model.T03)) +
                 (string.IsNullOrWhiteSpace(model.T04) ? 0 : double.Parse(model.T04)) +
                 (string.IsNullOrWhiteSpace(model.T05) ? 0 : double.Parse(model.T05)) +
                 (string.IsNullOrWhiteSpace(model.T06) ? 0 : double.Parse(model.T06)) +
                 (string.IsNullOrWhiteSpace(model.T07) ? 0 : double.Parse(model.T07)) +
                 (string.IsNullOrWhiteSpace(model.T08) ? 0 : double.Parse(model.T08)) +
                 (string.IsNullOrWhiteSpace(model.T09) ? 0 : double.Parse(model.T09)) +
                 (string.IsNullOrWhiteSpace(model.T10) ? 0 : double.Parse(model.T10)) +
                 (string.IsNullOrWhiteSpace(model.T11) ? 0 : double.Parse(model.T11)) +
                 (string.IsNullOrWhiteSpace(model.T12) ? 0 : double.Parse(model.T12)) +
                 (string.IsNullOrWhiteSpace(model.T13) ? 0 : double.Parse(model.T13)) +
                 (string.IsNullOrWhiteSpace(model.T14) ? 0 : double.Parse(model.T14)) +
                 (string.IsNullOrWhiteSpace(model.T15) ? 0 : double.Parse(model.T15)) +
                 (string.IsNullOrWhiteSpace(model.T16) ? 0 : double.Parse(model.T16)) +
                 (string.IsNullOrWhiteSpace(model.T17) ? 0 : double.Parse(model.T17)) +
                 (string.IsNullOrWhiteSpace(model.T18) ? 0 : double.Parse(model.T18)) +
                 (string.IsNullOrWhiteSpace(model.T19) ? 0 : double.Parse(model.T19)) +
                 (string.IsNullOrWhiteSpace(model.T20) ? 0 : double.Parse(model.T20)) +
                 (string.IsNullOrWhiteSpace(model.T21) ? 0 : double.Parse(model.T21)) +
                 (string.IsNullOrWhiteSpace(model.T22) ? 0 : double.Parse(model.T22)) +
                 (string.IsNullOrWhiteSpace(model.T23) ? 0 : double.Parse(model.T23))
                 ).ToString();
            return val;
        }
    }

    public class TimeLineOrgData : Time
    {
        public string? ORGANIZATION_CODE { get; set; }
        public string? ORGANIZATION_NAME { get; set; }
        public string? NUM_SERVICE { get; set; }
        public string? MAX_DROP { get; set; }
        public string? Progress { get; set; }
        public static string ConverModel(TimeLineOrgData model)
        {
            var val = (
                 (string.IsNullOrWhiteSpace(model.T00) ? 0 : double.Parse(model.T00)) +
                 (string.IsNullOrWhiteSpace(model.T01) ? 0 : double.Parse(model.T01)) +
                 (string.IsNullOrWhiteSpace(model.T02) ? 0 : double.Parse(model.T02)) +
                 (string.IsNullOrWhiteSpace(model.T03) ? 0 : double.Parse(model.T03)) +
                 (string.IsNullOrWhiteSpace(model.T04) ? 0 : double.Parse(model.T04)) +
                 (string.IsNullOrWhiteSpace(model.T05) ? 0 : double.Parse(model.T05)) +
                 (string.IsNullOrWhiteSpace(model.T06) ? 0 : double.Parse(model.T06)) +
                 (string.IsNullOrWhiteSpace(model.T07) ? 0 : double.Parse(model.T07)) +
                 (string.IsNullOrWhiteSpace(model.T08) ? 0 : double.Parse(model.T08)) +
                 (string.IsNullOrWhiteSpace(model.T09) ? 0 : double.Parse(model.T09)) +
                 (string.IsNullOrWhiteSpace(model.T10) ? 0 : double.Parse(model.T10)) +
                 (string.IsNullOrWhiteSpace(model.T11) ? 0 : double.Parse(model.T11)) +
                 (string.IsNullOrWhiteSpace(model.T12) ? 0 : double.Parse(model.T12)) +
                 (string.IsNullOrWhiteSpace(model.T13) ? 0 : double.Parse(model.T13)) +
                 (string.IsNullOrWhiteSpace(model.T14) ? 0 : double.Parse(model.T14)) +
                 (string.IsNullOrWhiteSpace(model.T15) ? 0 : double.Parse(model.T15)) +
                 (string.IsNullOrWhiteSpace(model.T16) ? 0 : double.Parse(model.T16)) +
                 (string.IsNullOrWhiteSpace(model.T17) ? 0 : double.Parse(model.T17)) +
                 (string.IsNullOrWhiteSpace(model.T18) ? 0 : double.Parse(model.T18)) +
                 (string.IsNullOrWhiteSpace(model.T19) ? 0 : double.Parse(model.T19)) +
                 (string.IsNullOrWhiteSpace(model.T20) ? 0 : double.Parse(model.T20)) +
                 (string.IsNullOrWhiteSpace(model.T21) ? 0 : double.Parse(model.T21)) +
                 (string.IsNullOrWhiteSpace(model.T22) ? 0 : double.Parse(model.T22)) +
                 (string.IsNullOrWhiteSpace(model.T23) ? 0 : double.Parse(model.T23))
                 ).ToString();
            return val;
        }
    }

    public class TimeLineOrgSumData : Time
    {
        public string? SUM_SERVICE { get; set; }
        public string? SUM_DROP { get; set; }
        public string? Progress { get; set; }
    }

    public class TimeLineOrgSaleData : Time
    {
        public string? ORGANIZATION_CODE { get; set; }
        public string? ORGANIZATION_NAME { get; set; }
        public string? SUM_REALSALE { get; set; }
        public string? SUM_AMOUT { get; set; }
        public string? Progress { get; set; }
        public static string ConverModel(TimeLineOrgSaleData model)
        {
           var val = (
                (string.IsNullOrWhiteSpace(model.T00) ? 0 : double.Parse(model.T00)) + 
                (string.IsNullOrWhiteSpace(model.T01) ? 0 : double.Parse(model.T01)) +
                (string.IsNullOrWhiteSpace(model.T02) ? 0 : double.Parse(model.T02)) +
                (string.IsNullOrWhiteSpace(model.T03) ? 0 : double.Parse(model.T03)) +
                (string.IsNullOrWhiteSpace(model.T04) ? 0 : double.Parse(model.T04)) +
                (string.IsNullOrWhiteSpace(model.T05) ? 0 : double.Parse(model.T05)) +
                (string.IsNullOrWhiteSpace(model.T06) ? 0 : double.Parse(model.T06)) +
                (string.IsNullOrWhiteSpace(model.T07) ? 0 : double.Parse(model.T07)) +
                (string.IsNullOrWhiteSpace(model.T08) ? 0 : double.Parse(model.T08)) +
                (string.IsNullOrWhiteSpace(model.T09) ? 0 : double.Parse(model.T09)) +
                (string.IsNullOrWhiteSpace(model.T10) ? 0 : double.Parse(model.T10)) +
                (string.IsNullOrWhiteSpace(model.T11) ? 0 : double.Parse(model.T11)) +
                (string.IsNullOrWhiteSpace(model.T12) ? 0 : double.Parse(model.T12)) +
                (string.IsNullOrWhiteSpace(model.T13) ? 0 : double.Parse(model.T13)) +
                (string.IsNullOrWhiteSpace(model.T14) ? 0 : double.Parse(model.T14)) +
                (string.IsNullOrWhiteSpace(model.T15) ? 0 : double.Parse(model.T15)) +
                (string.IsNullOrWhiteSpace(model.T16) ? 0 : double.Parse(model.T16)) +
                (string.IsNullOrWhiteSpace(model.T17) ? 0 : double.Parse(model.T17)) +
                (string.IsNullOrWhiteSpace(model.T18) ? 0 : double.Parse(model.T18)) +
                (string.IsNullOrWhiteSpace(model.T19) ? 0 : double.Parse(model.T19)) +
                (string.IsNullOrWhiteSpace(model.T20) ? 0 : double.Parse(model.T20)) +
                (string.IsNullOrWhiteSpace(model.T21) ? 0 : double.Parse(model.T21)) +
                (string.IsNullOrWhiteSpace(model.T22) ? 0 : double.Parse(model.T22)) +
                (string.IsNullOrWhiteSpace(model.T23) ? 0 : double.Parse(model.T23)) 
                ).ToString();
            return val;
        }
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
        public string? T00 {get;set;}
    }
}
