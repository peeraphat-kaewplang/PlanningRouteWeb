
using PlanningRouteWeb.Models;

namespace PlanningRouteWeb.Services.V2
{
    public interface ICommonService
    {
        Task ShowAlert(ToastModel options);
    }
}
