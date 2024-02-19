using PlanningRouteWeb.Helpers;

namespace PlanningRouteWeb.Models
{
    public class WindowDimension
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class columnSet
    {
        public Week Week { get; set; } = new Week();
        public IDictionary<string, ColumnProperty> column { get; set; } = new Dictionary<string, ColumnProperty>();
    }
    public class Week
    {
        public bool Week1 { get; set; }
        public bool Week1Value { get; set; }
        public bool Week2 { get; set; }
        public bool Week2Value { get; set;}
    }
    public class ColumnProperty
    {
        public string FieldDate { get; set; } = string.Empty;
        public string FieldDateName { get; set; } = string.Empty;
        public string FieldRankName { get; set; } = string.Empty;
        public string FieldValueName { get; set; } = string.Empty;
        public string ClassColor { get; set; } = string.Empty;
        public bool IsCurrent { get; set; }
    }

    public class ColumnFooter
    {
        public string FieldDate { get; set; } = string.Empty;
        public int COUNT_STATUS_MANUAL { get; set; }
        public int COUNT_STATUS_MANUAL2 { get; set; }
        public int MAX_DROP { get; set; }
        public bool IsCurrent { get; set; }
        public double SUM_SALETOTAL { get; set; }
        public double SUM_SALETOTAL_TOTAL { get; set; }
    }

    public class DayObject
    {
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
    }

    public class MonthObject
    {
        public string Number { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
    }


    public class ChangeActionButton
    {
        public string Action { get; set; } = "create";
        public List<DateError> Date { get; set; } = new();
    }

    public class ActionButton 
    {
        public string Action { get; set; } = "create";
        public int Week { get; set; }
        public List<DateError> Date { get; set; } = new();
    }

    public class DateError
    {
        public string Date { get; set; } = string.Empty;
        public bool Error { get; set; }
        public int? Rank { get; set; }
    }


    public class Permission
    {
        public string? ENABLED { get; set; }
        public string? EXPIRED_DAYS { get; set; }
        public string? FAIL_COUNT { get; set; }
        public string? HoldInfos { get; set; }
        public string? LOCKED { get; set; }
        public string? LoginDate { get; set; }
        public string? SELF_RENEW { get; set; }
        public string? Token { get; set; }
        public string? firstname { get; set; }
        public string? id { get; set; }
        public List<Permissions> permissions { get; set; } = new();
        public string? username { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Errorcode { get; set; }
    }

    public class Permissions
    {
        public List<PermissionList> permissionList { get; set; } = new();
    }

    public class PermissionList
    {
        public string? form_code { get; set; }
        public string? form_name { get; set; }
        public string? function_allow { get; set; }
        public string? function_code { get; set; }
        public string? function_name { get; set; }
        public string? function_value { get; set; }
        public string? name { get; set; }
    }


}