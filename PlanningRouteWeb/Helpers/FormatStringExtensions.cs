using System.Globalization;

namespace PlanningRouteWeb.Helpers
{
    public static class FormatStringExtensions
    {
        public static string ToStringNumberFormat<T>(this T value , bool isDigit = true)
        {
            if (typeof(T) == typeof(double) || typeof(T) == typeof(string) || typeof(T) == typeof(int) )
            {
                double.TryParse(value!.ToString()!, out var valueAsDouble);
                if (valueAsDouble == 0 || (valueAsDouble < 10 && valueAsDouble > 0)) return valueAsDouble.ToString();

                return valueAsDouble.ToString(isDigit ? "0,0.00" : "0,0", CultureInfo.InvariantCulture);
            }
           
            return "0";
        }
    }
}
