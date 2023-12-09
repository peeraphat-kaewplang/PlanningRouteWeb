using PlanningRouteWeb.Models;
using PlanningRouteWeb.Services;
using System.Globalization;
using System.Text.RegularExpressions;

namespace PlanningRouteWeb.Helpers
{
    public static partial class DateTimeExtensions
    {
        public static DateTime FirstDayOfWeek(this DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;

            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-diff).Date;
        }
        public static DateTime LastDayOfWeek(this DateTime dt) 
            => dt.FirstDayOfWeek().AddDays(7);
        public static string ToStringDate(this DateTime date, string format = "dd/MM/yyyy")
           => date.ToString(format ,CultureInfo.GetCultureInfo("en-US"));
        public static bool ToContainsDate(this DateTime date, string current)
            => date.ToStringDate("dd/MM/yyyy").Contains(current);
        public static DateTime StringToDateTime(this string date, string format = "dd/MM/yyyy")
            => DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
        
        public static DateTime FirstDayOfMonth(this DateTime inDate) 
            => new DateTime(inDate.Year, inDate.Month, 1);
        public static DateTime LastDayOfMonth(this DateTime inDate)
           => new DateTime(inDate.Year, inDate.Month, DateTime.DaysInMonth(inDate.Year, inDate.Month));
        public static int GetWeekNumberOfMonth(this DateTime date)
            => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        public static bool CheckDateInCurrentWeek(this DateTime date , DateTime dateiIn , int addDay)
        {
            var currentDate = dateiIn.AddDays(addDay);
            var week = date.GetWeekNumberOfMonth();
            var currentWeek = currentDate.GetWeekNumberOfMonth();

            if (week == currentWeek)
            {
                if (date > currentDate)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (week - 1 == currentWeek)
            {
                return true;
            }
            return false;
        }
       
    }
}
