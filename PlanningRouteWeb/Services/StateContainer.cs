namespace PlanningRouteWeb.Services
{
    public class StateContainer
    {
        public int _beforeConfig = 0;
        public int BeforeConfig
        {
            get => _beforeConfig;
            set
            {
                _beforeConfig = value;
                NotifyStateChanged();
            }
        }

        
        public DateTime _dateTime { get; set; } = DateTime.Now;

        public DateTime DateCurrent
        {
            get => _dateTime;
        }

        public int defultYear = 2023;

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
