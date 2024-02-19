using System.Reflection.PortableExecutable;

namespace PlanningRouteWeb.Models
{
    public class OrganizationResponse : HttpResponse
    {
        public List<OrganizationData> Data { get; set; } = new();
    }
    public class RouteResponse : HttpResponse
    {
        public List<RouteData> Data { get; set; } = new();
    }
    public class PanningMasterResponse : HttpResponse
    {
        public PlanningResponse Data { get; set; } = new();
    }

    public class PlanningResponse
    {
        public Target Target { get; set; } = new();
        public List<PlanningMasterData> Plan { get; set; } = new();
    }
    public class Target
    {
        public string DROP_PER_DAY { get; set; } = string.Empty;
        public string VALUE_PER_DAY { get; set; } = string.Empty;
        public string VALUE_PER_MONTH { get; set; } = string.Empty;
        public string BASKET_SYSTEM { get; set; } = string.Empty;
    }

    public class Target2
    {
        public int DROP_PER_DAY { get; set; } 
        public int VALUE_PER_DAY { get; set; } 
        public int VALUE_PER_MONTH { get; set; }
        public bool SYSTEMCART { get;set; }
    }

    public class TargetSave : Target
    {
        public string ORG { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
    }

    public class SavePlanResponse : HttpResponse
    {
        public string Status { get; set; } = string.Empty;
    }
    public class OrganizationData
    {
        public string ORGANIZATION_CODE { get; set; } = string.Empty;
        public string ORGANIZATION_NAME { get; set; } = string.Empty;
        public string ORGANIZATION_NO { get; set; } = string.Empty;
    }
    public class RouteData
    {
        public string ORGANIZATION_CODE { get; set; } = string.Empty;
        public string ROUTE_CODE { get; set; } = string.Empty;
        public string ROUTE_NAME { get; set; } = string.Empty;
        public static RouteData ConverModel(RouteData model)
        {
            string[] ro = model.ROUTE_NAME.Split(new string[] { model.ROUTE_CODE }, StringSplitOptions.None);
            return new RouteData
            {
                ORGANIZATION_CODE = model.ORGANIZATION_CODE,
                ROUTE_CODE = model.ROUTE_CODE,
                ROUTE_NAME = $"{model.ROUTE_CODE} : {(ro.Count() == 1 ? model.ROUTE_NAME : ro[1])}"
            };
        }
    }

    public class PlanningMasterData : DayMaster
    {
        public string YEARMONTH { get; set; } = string.Empty;
        public string ORGANIZATION_CODE { get; set; } = string.Empty;
        public string ROUTE_CODE { get; set; } = string.Empty;
        public string ROUTE_NAME { get; set; } = string.Empty;
        public string CUSTOMER_CODE { get; set; } = string.Empty;
        public string CUSTOMER_NAME { get; set; } = string.Empty;
        public string LOCATION_CODE { get; set; } = string.Empty;
        public string LOCATION_NAME { get; set; } = string.Empty;
        public string MACHINE_CODE { get; set; } = string.Empty;
        public string MACHINE_MODEL { get; set; } = string.Empty;
        public string CHANGE_ACTION { get; set; } = string.Empty;
        public string TOTAL_FEE { get; set; } = string.Empty;
        public string BEFORE_SALE { get; set; } = string.Empty;
        public string BEFORE_MTD { get; set; } = string.Empty;
        public string CURRENT_MTD { get; set; } = string.Empty;
        public string DROPWEEK { get; set; } = string.Empty;
        public string DROPDAY { get; set; } = string.Empty;
        public string REMARK { get; set; } = string.Empty;
        public string MSORT { get; set; } = string.Empty;
        public string SALE_LAST_WEEK { get; set; } = string.Empty;
        public string SALE_LAST_WEEK_END { get; set; } = string.Empty;
        public List<PlanningDetail> GETPLAN_DETAIL { get; set; } = new();
        public Dictionary<string, List<string>> Week1 { get; set; } = new();
        public Dictionary<string, List<string>> Week2 { get; set; } = new();
    }


    public class PlanningMasterSave : DayMaster
    {
        public string YEARMONTH { get; set; } = string.Empty;
        public string ORGANIZATION_CODE { get; set; } = string.Empty;
        public string ROUTE_CODE { get; set; } = string.Empty;
        public string ROUTE_NAME { get; set; } = string.Empty;
        public string CUSTOMER_CODE { get; set; } = string.Empty;
        public string CUSTOMER_NAME { get; set; } = string.Empty;
        public string LOCATION_CODE { get; set; } = string.Empty;
        public string LOCATION_NAME { get; set; } = string.Empty;
        public string MACHINE_CODE { get; set; } = string.Empty;
        public string MACHINE_MODEL { get; set; } = string.Empty;
        public string CHANGE_ACTION { get; set; } = string.Empty;
        public string TOTAL_FEE { get; set; } = string.Empty;
        public string BEFORE_SALE { get; set; } = string.Empty;
        public string BEFORE_MTD { get; set; } = string.Empty;
        public string CURRENT_MTD { get; set; } = string.Empty;
        public string DROPWEEK { get; set; } = string.Empty;
        public string DROPDAY { get; set; } = string.Empty;
        public string REMARK { get; set; } = string.Empty;
        public string MSORT { get; set; } = string.Empty;
        public string SALE_LAST_WEEK { get; set; } = string.Empty;
        public string SALE_LAST_WEEK_END { get; set; } = string.Empty;
        public List<PlanningDetail> SAVEPLAN_detail { get; set; } = new();
    }

    public class Group1 : DayMaster2
    {
        public string YEARMONTH { get; set; } = string.Empty;
        public string ORGANIZATION_CODE { get; set; } = string.Empty;
        public string ROUTE_CODE { get; set; } = string.Empty;
        public string ROUTE_NAME { get; set; } = string.Empty;
        public string CUSTOMER_CODE { get; set; } = string.Empty;
        public string CUSTOMER_NAME { get; set; } = string.Empty;
        public string LOCATION_CODE { get; set; } = string.Empty;
        public string LOCATION_NAME { get; set; } = string.Empty;
        public string MACHINE_CODE { get; set; } = string.Empty;
        public string MACHINE_MODEL { get; set; } = string.Empty;
        public string CHANGE_ACTION { get; set; } = string.Empty;
        public string TOTAL_FEE { get; set; } = string.Empty;
        public string BEFORE_SALE { get; set; } = string.Empty;
        public string BEFORE_MTD { get; set; } = string.Empty;
        public string CURRENT_MTD { get; set; } = string.Empty;
        public int DROPWEEK { get; set; }
        public int DROPDAY { get; set; }
        public string REMARK { get; set; } = string.Empty;
        public string MSORT { get; set; } = string.Empty;
        public double SALE_LAST_WEEK { get; set; }
        public double SALE_LAST_WEEK_END { get; set; }
        public bool IS_DUPLICATE { get; set; }
        
    }
    public class Group2 : Group1
    {
        public List<PlanningDetail2> GETPLAN_DETAIL { get; set; } = new();
    }
    public class PlanningMasterData2 : Group1
    {
        public List<PlanningDetail2> GETPLAN_DETAIL { get; set; } = new();
        public List<Group2> GroupData { get; set; } = new();
        public Dictionary<string, List<string>> Week1 { get; set; } = new();
        public Dictionary<string, List<string>> Week2 { get; set; } = new();
    }

    public class PlanningDataMapter
    {   
        public string YEARMONTH { get; set; } = string.Empty;
        public string ORGANIZATION_CODE { get; set; } = string.Empty;
        public string ROUTE_CODE { get; set; } = string.Empty;
        public string ROUTE_NAME { get; set; } = string.Empty;
        public string CUSTOMER_CODE { get; set; } = string.Empty;
        public string CUSTOMER_NAME { get; set; } = string.Empty;
        public string LOCATION_CODE { get; set; } = string.Empty;
        public string LOCATION_NAME { get; set; } = string.Empty;
        public string MACHINE_CODE { get; set; } = string.Empty;
        public string MACHINE_MODEL { get; set; } = string.Empty;
        public string CHANGE_ACTION { get; set; } = string.Empty;
        public string TOTAL_FEE { get; set; } = string.Empty;
        public string BEFORE_SALE { get; set; } = string.Empty;
        public string BEFORE_MTD { get; set; } = string.Empty;
        public string CURRENT_MTD { get; set; } = string.Empty;
        public int DROPWEEK { get; set; }
        public int DROPDAY { get; set; }
        public string REMARK { get; set; } = string.Empty;
        public List<ItemGroup> ITEMS_GROUP { get; set; } = new();
        
    }

    public class ItemGroup : DayMaster2
    {
        public string MSORT { get; set; } = string.Empty;
        public bool IS_DUPLICATE { get; set; }
         public List<PlanningDetail2> GETPLAN_DETAIL { get; set; } = new();
    }

    public class DayMaster
    {
        public string MONDAY { get; set; } = string.Empty;
        public string TUESDAY { get; set; } = string.Empty;
        public string WEDNESDAY { get; set; } = string.Empty;
        public string THURSDAY { get; set; } = string.Empty;
        public string FRIDAY { get; set; } = string.Empty;
        public string SATURDAY { get; set; } = string.Empty;
        public string SUNDAY { get; set; } = string.Empty;
    }

    public class DayMaster2
    {
        public bool MONDAY { get; set; }
        public bool TUESDAY { get; set; }
        public bool WEDNESDAY { get; set; }
        public bool THURSDAY { get; set; }
        public bool FRIDAY { get; set; }
        public bool SATURDAY { get; set; }
        public bool SUNDAY { get; set; }
    }


    public class PlanningDetail
    {
        public string CALENDAR_DATE { get; set; } = string.Empty;
        public string STATUS_ORIGINAL { get; set; } = string.Empty;
        public string STATUS_MANUAL { get; set; } = string.Empty;
        public string DOC_TYPE { get; set; } = string.Empty;
        public string SALETOTAL { get; set; } = string.Empty;
        public string RANK { get; set; } = string.Empty;
        public string MAX_DROP { get; set; } = string.Empty;
        public string AMOUNT { get; set; } = string.Empty;
        public string HOLIDAY { get; set; } = string.Empty;
        public string MACHINE_CODE { get; set; } = string.Empty;
        public string CHANGEPRODUCT { get; set; } = string.Empty;
    }

    public class PlanningDetail2
    {
        public string CALENDAR_DATE { get; set; } = string.Empty;
        public string STATUS_ORIGINAL { get; set; } = string.Empty;
        public bool STATUS_MANUAL { get; set; } 
        public string DOC_TYPE { get; set; } = string.Empty;
        public double SALETOTAL { get; set; }
        public int? RANK { get; set; }
        public bool IsCurrent { get; set; }
        public string MAX_DROP { get; set; } = string.Empty;
        public double AMOUNT { get; set; } 
        public string HOLIDAY { get; set; } = string.Empty;
        public string MACHINE_CODE { get; set; } = string.Empty;
        public string CHANGEPRODUCT { get; set; } = string.Empty;
    }

   
}