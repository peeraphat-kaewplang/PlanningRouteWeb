using PlanningRouteWeb.Models;

namespace PlanningRouteWeb.Helpers
{
    public static class CalDataPlanning
    {
        public static List<PlanningDetail2> CalEstimate( PlanningDetail2 current, List<PlanningDetail2> records)
        {
            var stop = false;
            var stack = new List<PlanningDetail2>();
            var first = GetDatetimeClass.currentDate.FirstDayOfMonth();
            var last = GetDatetimeClass.currentDate.LastDayOfMonth();

            var recordsCal = records.Select(x =>
            {
                    if (x.CALENDAR_DATE.StringToDateTime() >= first && x.CALENDAR_DATE.StringToDateTime() <= last)
                    {
                        if (x.STATUS_MANUAL && x.CALENDAR_DATE.StringToDateTime() < current.CALENDAR_DATE.StringToDateTime())
                        {
                            stack = new List<PlanningDetail2>();
                        }
                        else if (current.CALENDAR_DATE.StringToDateTime() >= first && x.CALENDAR_DATE.StringToDateTime() < current.CALENDAR_DATE.StringToDateTime())
                        {
                            stack.Add(x);
                        }

                        if (x.CALENDAR_DATE.StringToDateTime() == current.CALENDAR_DATE.StringToDateTime() && x.DOC_TYPE != "1")
                        {
                            if (x.STATUS_MANUAL)
                            {
                                x.SALETOTAL = stack.Sum(x => x.AMOUNT) + x.AMOUNT;
                                
                                if(stack.Count() != 0)
                                {
                                    stack = new List<PlanningDetail2>();
                                }
                            }
                            else
                            {
                                x.SALETOTAL = 0;
                                stack.Add(x);
                            }
                        }

                        if (x.CALENDAR_DATE.StringToDateTime() > current.CALENDAR_DATE.StringToDateTime() && x.DOC_TYPE != "1")
                        {
                            if (!x.STATUS_MANUAL)
                            {
                                stack.Add(x);
                            }
                            else if (x.STATUS_MANUAL && !stop && !current.STATUS_MANUAL)
                            {
                                stop = true;
                                x.SALETOTAL = stack.Sum(x => x.AMOUNT) + x.AMOUNT;
                            }
                            else if (x.STATUS_MANUAL && !stop && current.STATUS_MANUAL)
                            {
                                x.SALETOTAL = stack.Sum(x => x.AMOUNT) + x.AMOUNT;
                            }
                        }
                    }
                return x;
            })
            .ToList();

            return recordsCal;
        }
    }
}
