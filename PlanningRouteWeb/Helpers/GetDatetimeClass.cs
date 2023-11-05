using PlanningRouteWeb.Models;

namespace PlanningRouteWeb.Helpers
{
    public static class GetDatetimeClass
    {
        public static List<DayObject> defultday = new List<DayObject>()
        {
            new DayObject { Number = 1 , Name = "จ" , FullName = "Monday"  },
            new DayObject { Number = 2 ,Name = "อ" ,FullName = "Tuesday" },
            new DayObject { Number = 3 ,Name = "พ" ,FullName = "Wednesday" },
            new DayObject { Number = 4 , Name = "พฤ" ,FullName = "Thursday" },
            new DayObject { Number = 5 , Name = "ศ" ,FullName = "Friday" },
            new DayObject { Number = 6 ,Name = "ส" ,FullName = "Saturday" },
            new DayObject { Number = 7 ,Name = "อา" ,FullName = "Sunday" },
        };

        public static List<MonthObject> monthObjects = new List<MonthObject>
        {
            new MonthObject {Number = "01" , Name = "มกราคม" ,ShortName = "ม.ค."},
            new MonthObject {Number = "02" , Name = "กุมภาพันธ์",ShortName = "ก.พ."},
            new MonthObject {Number = "03" , Name = "มีนาคม",ShortName = "มี.ค."},
            new MonthObject {Number = "04" , Name = "เมษายน",ShortName = "เม.ย."},
            new MonthObject {Number = "05" , Name = "พฤษภาคม",ShortName = "พ.ค."},
            new MonthObject {Number = "06" , Name = "มิถุนายน",ShortName = "มิ.ย."},
            new MonthObject {Number = "07" , Name = "กรกฎาคม",ShortName = "ก.ค."},
            new MonthObject {Number = "08" , Name = "สิงหาคม",ShortName = "ส.ค."},
            new MonthObject {Number = "09" , Name = "กันยายน",ShortName = "ก.ย."},
            new MonthObject {Number = "10" , Name = "ตุลาคม",ShortName = "ต.ค."},
            new MonthObject {Number = "11" , Name = "พฤศจิกายน",ShortName = "พ.ย."},
            new MonthObject {Number = "12" , Name = "ธันวาคม",ShortName = "ธ.ค."},
        };

        public static DateTime currentDate = DateTime.Now;
    }
}
