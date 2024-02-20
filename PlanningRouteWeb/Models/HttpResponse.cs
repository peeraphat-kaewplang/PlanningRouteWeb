namespace PlanningRouteWeb
{
    public class HttpResponse
    {
        public string ErrorMessage { get; set; } = string.Empty;
        public string Errorcode { get; set; } = string.Empty;
        public string ResponseDate { get; set; } = string.Empty;
    }

    public class ErrorMessageRes
    {
        public bool Error { get; set; } = false;
        public string? ErrorMessage { get; set; }
    }
}