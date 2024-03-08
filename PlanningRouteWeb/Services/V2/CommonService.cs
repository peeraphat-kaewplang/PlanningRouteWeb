using Microsoft.JSInterop;
using PlanningRouteWeb.Models;

namespace PlanningRouteWeb.Services.V2
{
    public class CommonService : ICommonService
    {
        private readonly IJSRuntime _iJSRuntime;

        public CommonService(IJSRuntime iJSRuntime)
        {
            _iJSRuntime = iJSRuntime;
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
