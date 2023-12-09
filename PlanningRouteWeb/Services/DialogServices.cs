using Microsoft.AspNetCore.Components;
using PlanningRouteWeb.Interfaces;
using Radzen;

namespace PlanningRouteWeb.Services
{
    public class DialogServices : IDialogService
    {
        private readonly DialogService _dialogService;
        private System.Threading.ManualResetEvent Trigger = new System.Threading.ManualResetEvent(false);

        public DialogServices(DialogService dialogService )
        {
            _dialogService = dialogService;
        }

        public async Task BusyDialog(string message)
        {
           
            await _dialogService.OpenAsync("", ds =>
            {
                RenderFragment content = b =>
                {
                    b.OpenElement(0, "RadzenRow");

                    b.OpenElement(1, "RadzenColumn");
                    b.AddAttribute(2, "Size", "12");

                    b.AddContent(3, message);

                    b.CloseElement();
                    b.CloseElement();
                };
                return content;
            }, new DialogOptions() { ShowTitle = false, Style = "min-height:auto;min-width:auto;width:auto", CloseDialogOnEsc = false });
        }
        public void DialogClose()
        {
            _dialogService.Close();
        }
    }
}
