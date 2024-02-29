using PlanningRouteWeb.Interfaces.V2;
using PlanningRouteWeb.Models.V2;

namespace PlanningRouteWeb.Services.V2
{
    public class TimelineService : ITimelineService
    {
        public async Task<Tuple<ErrorMessageRes, List<TimeLineOrgData>>> GetTimeLine()
        {
            var error = new ErrorMessageRes();
            var data = new List<TimeLineOrgData>();
            try
            {
                data = new List<TimeLineOrgData>
                {
                    new TimeLineOrgData
                    {
                       
                        ORGANIZATION_CODE ="WAN",
                        NUM_SERVICE = "34",
                        MAX_DROP = "50",
                        T01 = "0",
                        T02 = "0",
                        T03 = "0",
                        T04 = "0",
                        T05 = "0",
                        T06 = "0",
                        T07 = "0",
                        T08 = "2",
                        T09 = "3",
                        T10 = "3",
                        T11 = "3",
                        T12 = "5",
                        T13 = "5",
                        T14 = "5",
                        T15 = "5",
                        T16 = "3",
                        T17 = "0",
                        T18 = "0",
                        T19 = "0",
                        T20 = "0",
                        T21 = "0",
                        T22 = "0",
                        T23 = "0",
                        T24 = "0",
                    }
                };
            }
            catch (Exception ex)
            {
                error.Error = true;
                error.ErrorMessage = ex.Message;
            }

            return Tuple.Create(error, data);
        }
    }
}

//{
//    ROUTE_CODE = "R01",
//                        ORGANIZATION_CODE = "WAN",
//                        NUM_SERVICE = "34",
//                        MAX_DROP = "50",
//                        T01 = "0",
//                        T02 = "0",
//                        T03 = "0",
//                        T04 = "0",
//                        T05 = "0",
//                        T06 = "0",
//                        T07 = "0",
//                        T08 = "2",
//                        T09 = "3",
//                        T10 = "3",
//                        T11 = "3",
//                        T12 = "5",
//                        T13 = "5",
//                        T14 = "5",
//                        T15 = "5",
//                        T16 = "3",
//                        T17 = "0",
//                        T18 = "0",
//                        T19 = "0",
//                        T20 = "0",
//                        T21 = "0",
//                        T22 = "0",
//                        T23 = "0",
//                        T24 = "0",
//                    }
