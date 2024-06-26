namespace PlanningRouteWeb.Models
{
    public class ToastModel
    {
        public string? messang {get;set;}
        public string? action {get; set;} = "success";
        public bool autohide {get; set;} =true;
        public int delay {get; set;} = 3000;
    }
}