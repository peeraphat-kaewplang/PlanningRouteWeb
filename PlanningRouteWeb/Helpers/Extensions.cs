using Newtonsoft.Json;
using PlanningRouteWeb.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PlanningRouteWeb.Helpers
{
    public static class Extensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
            => self.Select((item, index) => (item, index));

        public static List<ChangeProductGroup> FilterGroup(this List<ChangeProductGroup> data , int filter)
        {
            List<ChangeProductGroup> newData =new ();
            if (filter == 1)
            {
                newData = data.OrderByDescending(x => x.SLOT_REALPRICE).ToList();
            }
            else
            {
                newData = data.OrderBy(x => x.SLOT_REALPRICE).ToList();
            }

            return newData;
        }
    }
}