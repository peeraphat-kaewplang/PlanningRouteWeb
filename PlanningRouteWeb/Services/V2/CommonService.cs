using Microsoft.JSInterop;
using PlanningRouteWeb.Helpers;
using PlanningRouteWeb.Models;
using System.Globalization;

namespace PlanningRouteWeb.Services.V2
{
    public class CommonService : ICommonService
    {
        private readonly IJSRuntime _iJSRuntime;


        private readonly List<DisableCart> _disableCart;
        private readonly int _beforeConfig;

        public DateTime _dateNow { get; set; } = DateTime.Now;

        public CommonService(IJSRuntime iJSRuntime, IConfiguration configuration)
        {
            _iJSRuntime = iJSRuntime;
            _disableCart = configuration.GetSection("ConfigGeneral")!.GetSection("DisableCart")!.Get<List<DisableCart>>()!;
            _beforeConfig = configuration.GetValue<int>("ConfigGeneral:BeforeConfig")!;
        }

        public bool CheckDateInCurrentWeek(DateTime date , string org = "" , string route = "" , bool isCart = false)
        {
            var chkDisable = 0;
            var currentDate = _dateNow.AddDays(_beforeConfig);
            var week = date.GetWeekNumberOfMonth();
            var currentWeek = currentDate.GetWeekNumberOfMonth();

            if(_disableCart.Count() != 0)
                chkDisable = _disableCart.Where(x => x.ORG == org && x.ROUTE == route).Count();

            var year = DateTime.Now.Year;
            var lastWeek = ISOWeek.GetWeeksInYear(year);

            if (week == currentWeek)
            {
                if(chkDisable > 0 || isCart)
                {
                    if (date > currentDate.Date)
                        return true;
                    else
                        return false;
                }
                else
                {
                    if (date >= currentDate.Date)
                        return true;
                    else
                        return false;
                }
            }
            else if (week - 1 == currentWeek)
                return true;
            else if (lastWeek == currentWeek && week == 1)
                return true;
            return false;
        }

        public async Task ShowAlert(ToastModel options)
        {
            await _iJSRuntime.InvokeVoidAsync("toastTrigger",
              new ToastModel
              {
                  action = options.action,
                  messang = options.messang
              });
        }
    }
}
