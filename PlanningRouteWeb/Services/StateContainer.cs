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
       
        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
