namespace PlanningRouteWeb.Interfaces.V2
{
    public interface ISetDatetimeService
    {
        List<int> SetYear();
        bool CheckDateInCurrentWeek(DateTime date);
    }
}
