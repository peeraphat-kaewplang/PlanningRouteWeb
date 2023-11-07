namespace PlanningRouteWeb.Interfaces
{
    public interface IDialogService
    {
        Task BusyDialog(string message);
        void DialogClose ();
    }
}
