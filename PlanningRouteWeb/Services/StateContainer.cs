using PlanningRouteWeb.Models;

namespace PlanningRouteWeb.Services
{
    public class StateContainer
    {
        public bool _isLoading = false;
        public bool IsLoading { get => _isLoading; 
            set 
            {
                _isLoading = value;
                NotifyStateChanged();
            }
        }
        public string _textLoading = "กำลังโหลดข้อมูล...";
        public string TextLoading 
        { 
            get => _textLoading;
            set 
            {
                _textLoading = value;
                NotifyStateChanged();
            }
        } 

        public Permission PermissionUser { get; set; } = new();

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
