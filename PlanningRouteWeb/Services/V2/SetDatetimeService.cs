using PlanningRouteWeb.Helpers;
using PlanningRouteWeb.Interfaces.V2;
using System.Globalization;

namespace PlanningRouteWeb.Services.V2
{
    public class SetDatetimeService : ISetDatetimeService
    {
        private readonly StateContainer _stateContainer;

        public SetDatetimeService(StateContainer stateContainer)
        {
            _stateContainer = stateContainer;
        }
        public List<int> SetYear()
        {
            var year = DateTime.Now.Year;
            var y = year - _stateContainer.defultYear;

            var yList = new List<int>();

            if (y > 0)
            {
                for (var i = 0; i <= y; i++)
                {
                    yList.Add(_stateContainer.defultYear + i);
                }
            }
            else
            {
                yList.AddRange(new List<int> { _stateContainer.defultYear, _stateContainer.defultYear + 1 });
            }
            return yList;
        }

        public bool CheckDateInCurrentWeek(DateTime date)
        {
            var currentDate = DateTime.Now.AddDays(_stateContainer.BeforeConfig);
            var weekNumber = date.GetWeekNumberOfMonth();
            var currentWeek = currentDate.GetWeekNumberOfMonth();

            var year = DateTime.Now.Year;
            var lastWeek = ISOWeek.GetWeeksInYear(year);

            if (weekNumber == currentWeek)
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
            else if (weekNumber - 1 == currentWeek)
            {
                return true;
            }
            else if (lastWeek == currentWeek && weekNumber == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
