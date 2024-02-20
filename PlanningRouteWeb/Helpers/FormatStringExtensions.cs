using System.Globalization;

namespace PlanningRouteWeb.Helpers
{
    public static class FormatStringExtensions
    {
        public static string ToStringNumberFormat<T>(this T value)
        {
            if (typeof(T) == typeof(double) && double.TryParse(value!.ToString()!, out var valueAsDouble))
            {
                if (valueAsDouble == 0) return valueAsDouble.ToString();
                return valueAsDouble.ToString("0,0.00", CultureInfo.InvariantCulture);
            }
            return "0";
        }
    }
}
