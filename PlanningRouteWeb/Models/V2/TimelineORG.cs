namespace PlanningRouteWeb.Models.V2
{
    public class TimelineModelRes : HttpResponse
    {
        public TimeLineData1 Data { get; set; } = new();
    }

    public class TimelineMechineModelRes : HttpResponse
    {
        public List<TimelineMechineData> Data { get; set; } = new();

        public static TimelineMechineData1 ConvertToModel(TimelineMechineData model)
        {
            return new TimelineMechineData1
            {
                ROUTE_CODE = model.ROUTE_CODE,
                MACHINE_CODE = model.MACHINE_CODE,
                TIME_SERVICE = model.TIME_SERVICE.ToString(),
                STATUS_MANUAL = model.STATUS_MANUAL,
                SALETOTAL = model.SALETOTAL.ToString(),
                DOC_TYPE = model.DOC_TYPE.ToString(),
                AMOUNT =  model.AMOUNT,
                CUSTOMER_NAME = model.CUSTOMER_NAME
            };
        }
    }

    public class TimelineMechineModelRes1 : HttpResponse
    {
        public List<TimelineMechineData1> Data { get; set; } = new();

       
    }

    public class TimelineMechineData1
    {
        public string? ROUTE_CODE { get; set; }
        public string? MACHINE_CODE { get; set; }
        public string? TIME_SERVICE { get; set; }
        public string? STATUS_MANUAL { get; set; }
        public string? SALETOTAL { get; set; }
        public string? DOC_TYPE { get; set; }
        public double AMOUNT { get; set; }
        public string? CUSTOMER_NAME { get; set; }
    }

    public class TimelineMechineData
    {
        public string? ROUTE_CODE { get; set; }
        public string? MACHINE_CODE { get; set; }
        public double TIME_SERVICE { get; set; }
        public string? STATUS_MANUAL { get; set; }
        public double SALETOTAL { get; set; }
        public double DOC_TYPE { get; set; }
        public double AMOUNT { get; set; }
        public string? CUSTOMER_NAME { get; set; }
    }

    public class TimelineReq
    {
        public string? ORG { get; set; }
        public string? ROUTE { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? ReportShow { get; set; }
    }

    public class TimelineMechineReq
    {
        public string? ORG { get; set; }
        public string? ROUTE { get; set; }
        public string? MACHINE { get; set; }
        public string? TIMESERVICE { get; set; }
        public string? StartDate { get; set; }
    }

    public class TimelineModel : HttpResponse
    {
        public TimelineModel1 Data { get; set; } = new();
    }

    public class TimelineModel1
    {
        public ResultTimeline LISTITEM1 { get; set; } = new();
        public List<TimeLineMechine> LISTITEM2 { get; set; } = new();
    }

    public class ResultTimeline
    {
        public List<TimeLineData> TimelineList { get; set; } = new();
        public TimeLineData TimeLineSum { get; set; } = new();
    }
    public class TimeLineData1
    {
        public List<TimeLineData> LISTITEM1 { get; set; } = new();
        public List<TimeLineMechine> LISTITEM2 { get; set; } = new();
    }

    public class TimeLineMechine
    {
        public string ROUTE_CODE { get; set; } = string.Empty;
        public int SERVICE { get;  set; }
        public int MAX_SERVICE { get; set; }
        public List<TimeLineMechineDetail> DETAIL { get; set; } = new();
    }

    public class TimeLineMechineDetail
    {
        public string TIME_SERVICE { get; set; } = string.Empty;
        public List<TimeService> ITEMS { get; set; } = new();
    }

    public class TimeService
    {
        public string MACHINE_CODE { get; set; } = string.Empty;
        public string DOC_TYPE { get; set; } = string.Empty;
        public string SALETOTAL { get; set; } = string.Empty;
        public string AMOUNT { get; set; } = string.Empty;
        public string STATUS_MANUAL { get; set; } = string.Empty;
    }

    public class TimeLineData : Time
    {
        public string? ORGANIZATION_CODE { get; set; }
        public string? ORGANIZATION_NAME { get; set; }
        public string? ROUTE_CODE { get; set; }
        public double MAX_DROP { get; set; }
        public double SUM_AMOUT { get; set; }
        public double SUM_REALSALE { get; set; }
        public double ProgressDrop { get; set; }
        public double ProgressSale { get; set; }
        public static double ConverModelProgressDrop(TimeLineData model)
        {
            var val = (
                 model.T00_DROP +
                 model.T01_DROP +
                 model.T02_DROP +
                 model.T03_DROP +
                 model.T04_DROP +
                 model.T05_DROP +
                 model.T06_DROP +
                 model.T07_DROP +
                 model.T08_DROP +
                 model.T09_DROP +
                 model.T10_DROP +
                 model.T11_DROP +
                 model.T12_DROP +
                 model.T13_DROP +
                 model.T14_DROP +
                 model.T15_DROP +
                 model.T16_DROP +
                 model.T17_DROP +
                 model.T18_DROP +
                 model.T19_DROP +
                 model.T20_DROP +
                 model.T21_DROP +
                 model.T22_DROP +
                 model.T23_DROP
                 );
            return val;
        }
        public static double ConverModelProgressSale(TimeLineData model)
        {
            var val = (
                 model.T00_SALE +
                 model.T01_SALE +
                 model.T02_SALE +
                 model.T03_SALE +
                 model.T04_SALE +
                 model.T05_SALE +
                 model.T06_SALE +
                 model.T07_SALE +
                 model.T08_SALE +
                 model.T09_SALE +
                 model.T10_SALE +
                 model.T11_SALE +
                 model.T12_SALE +
                 model.T13_SALE +
                 model.T14_SALE +
                 model.T15_SALE +
                 model.T16_SALE +
                 model.T17_SALE +
                 model.T18_SALE +
                 model.T19_SALE +
                 model.T20_SALE +
                 model.T21_SALE +
                 model.T22_SALE +
                 model.T23_SALE
                 );
            return val;
        }
    }
    public class Time
    {
        public double T00_DROP { get; set; }
        public double T01_DROP { get; set; }
        public double T02_DROP { get; set; }
        public double T03_DROP { get; set; }
        public double T04_DROP { get; set; }
        public double T05_DROP { get; set; }
        public double T06_DROP { get; set; }
        public double T07_DROP { get; set; }
        public double T08_DROP { get; set; }
        public double T09_DROP { get; set; }
        public double T10_DROP { get; set; }
        public double T11_DROP { get; set; }
        public double T12_DROP { get; set; }
        public double T13_DROP { get; set; }
        public double T14_DROP { get; set; }
        public double T15_DROP { get; set; }
        public double T16_DROP { get; set; }
        public double T17_DROP { get; set; }
        public double T18_DROP { get; set; }
        public double T19_DROP { get; set; }
        public double T20_DROP { get; set; }
        public double T21_DROP { get; set; }
        public double T22_DROP { get; set; }
        public double T23_DROP { get; set; }
        public double T00_SALE { get; set; }
        public double T01_SALE { get; set; }
        public double T02_SALE { get; set; }
        public double T03_SALE { get; set; }
        public double T04_SALE { get; set; }
        public double T05_SALE { get; set; }
        public double T06_SALE { get; set; }
        public double T07_SALE { get; set; }
        public double T08_SALE { get; set; }
        public double T09_SALE { get; set; }
        public double T10_SALE { get; set; }
        public double T11_SALE { get; set; }
        public double T12_SALE { get; set; }
        public double T13_SALE { get; set; }
        public double T14_SALE { get; set; }
        public double T15_SALE { get; set; }
        public double T16_SALE { get; set; }
        public double T17_SALE { get; set; }
        public double T18_SALE { get; set; }
        public double T19_SALE { get; set; }
        public double T20_SALE { get; set; }
        public double T21_SALE { get; set; }
        public double T22_SALE { get; set; }
        public double T23_SALE { get; set; }
    }

}
