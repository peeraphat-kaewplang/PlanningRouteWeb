using PlanningRouteWeb.Helpers;
using PlanningRouteWeb.Models;
using PlanningRouteWeb.Services.V2;

namespace PlanningRouteWeb.Services
{
    public class StateContainer
    {
        private readonly ICommonService _commonService;

        public StateContainer(ICommonService commonService)
        {
            _commonService = commonService;
        }

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

        public PlanningDetail2 PlanningDetailModeltoModel(PlanningDetail model ,string org, string route , bool isCart)
        {
            return new PlanningDetail2
            {
                CALENDAR_DATE = model.CALENDAR_DATE,
                STATUS_ORIGINAL = model.STATUS_ORIGINAL,
                //STATUS_MANUAL = true,
                STATUS_MANUAL = !string.IsNullOrWhiteSpace(model.STATUS_MANUAL) ? model.STATUS_MANUAL == "Y" ? true : false : false,
                DOC_TYPE = model.DOC_TYPE,
                SALETOTAL = !string.IsNullOrWhiteSpace(model.SALETOTAL) ? double.Parse(model.SALETOTAL) : 0,
                RANK = !string.IsNullOrWhiteSpace(model.RANK) ? int.Parse(model.RANK) : null,
                IsCurrent = _commonService.CheckDateInCurrentWeek(DateTime.ParseExact(model.CALENDAR_DATE, "dd/MM/yyyy", null) , org ,route , isCart),
                MAX_DROP = model.MAX_DROP,
                AMOUNT = !string.IsNullOrWhiteSpace(model.AMOUNT) ? double.Parse(model.AMOUNT) : 0,
                HOLIDAY = model.HOLIDAY,
                MACHINE_CODE = model.MACHINE_CODE,
                CHANGEPRODUCT = model.CHANGEPRODUCT,
                REQUISITION = model.REQUISITION
            };
        }

        public PlanningMasterData2 PlanningMasterDataModeltoModel(PlanningMasterData model, IEnumerable<PlanningMasterData> Grp ,bool isCart)
        {
            var g = (double)(((double.Parse(model.TOTAL_SLOT_INSTALLPRICE) - double.Parse(model.TOTAL_COST_SALEPRICE)) / double.Parse(model.TOTAL_COST_SALEPRICE)) * 100);
            var data = new PlanningMasterData2
            {
                YEARMONTH = model.YEARMONTH,
                ORGANIZATION_CODE = model.ORGANIZATION_CODE,
                ROUTE_CODE = model.ROUTE_CODE,
                ROUTE_NAME = model.ROUTE_NAME,
                CUSTOMER_CODE = model.CUSTOMER_CODE,
                CUSTOMER_NAME = model.CUSTOMER_NAME,
                LOCATION_CODE = model.LOCATION_CODE,
                LOCATION_NAME = model.LOCATION_NAME,
                MACHINE_CODE = model.MACHINE_CODE,
                MACHINE_MODEL = model.MACHINE_MODEL,
                CHANGE_ACTION = model.CHANGE_ACTION,
                TOTAL_FEE = model.TOTAL_FEE,
                BEFORE_SALE = model.BEFORE_SALE,
                BEFORE_MTD = model.BEFORE_MTD,
                CURRENT_MTD = model.CURRENT_MTD,
                DROPWEEK = !string.IsNullOrWhiteSpace(model.DROPWEEK) ? int.Parse(model.DROPWEEK) : 0,
                DROPDAY = !string.IsNullOrWhiteSpace(model.DROPDAY) ? int.Parse(model.DROPDAY) : 0,
                REMARK = model.REMARK,
                MSORT = model.MSORT,
                IS_DUPLICATE = model.MSORT == "1" ? false : true,
                MONDAY = !string.IsNullOrWhiteSpace(model.MONDAY) ? true : false,
                TUESDAY = !string.IsNullOrWhiteSpace(model.TUESDAY) ? true : false,
                WEDNESDAY = !string.IsNullOrWhiteSpace(model.WEDNESDAY) ? true : false,
                THURSDAY = !string.IsNullOrWhiteSpace(model.THURSDAY) ? true : false,
                FRIDAY = !string.IsNullOrWhiteSpace(model.FRIDAY) ? true : false,
                SATURDAY = !string.IsNullOrWhiteSpace(model.SATURDAY) ? true : false,
                SUNDAY = !string.IsNullOrWhiteSpace(model.SUNDAY) ? true : false,
                SALE_LAST_WEEK = !string.IsNullOrWhiteSpace(model.SALE_LAST_WEEK) ? double.Parse(model.SALE_LAST_WEEK) : 0,
                SALE_LAST_WEEK_END = !string.IsNullOrWhiteSpace(model.SALE_LAST_WEEK_END) ? double.Parse(model.SALE_LAST_WEEK_END) : 0,
                ISONLINE = model.ISONLINE,
                IS_LOW_QTY = model.IS_LOW_QTY,
                GP_PRODUCT = model.GP_PRODUCT,
                GP = g.ToStringNumberFormat(),
                GETPLAN_DETAIL = model.GETPLAN_DETAIL.Select(x => PlanningDetailModeltoModel(x , model.ORGANIZATION_CODE , model.ROUTE_CODE , isCart)).ToList(),
                GroupData = Grp.Select(x => PlanningMasterDataModeltoModel2(x , isCart)).OrderBy(x => int.Parse(x.MSORT)).ToList(),
                Week1 = model.Week1,
                Week2 = model.Week2,
            };
            return data;
        }

        public Group2 PlanningMasterDataModeltoModel2(PlanningMasterData model, bool isCart)
        {
            return new Group2
            {
                YEARMONTH = model.YEARMONTH,
                ORGANIZATION_CODE = model.ORGANIZATION_CODE,
                ROUTE_CODE = model.ROUTE_CODE,
                ROUTE_NAME = model.ROUTE_NAME,
                CUSTOMER_CODE = model.CUSTOMER_CODE,
                CUSTOMER_NAME = model.CUSTOMER_NAME,
                LOCATION_CODE = model.LOCATION_CODE,
                LOCATION_NAME = model.LOCATION_NAME,
                MACHINE_CODE = model.MACHINE_CODE,
                MACHINE_MODEL = model.MACHINE_MODEL,
                CHANGE_ACTION = model.MACHINE_CODE == "19785" ? "C" : "",
                TOTAL_FEE = model.TOTAL_FEE,
                BEFORE_SALE = model.BEFORE_SALE,
                BEFORE_MTD = model.BEFORE_MTD,
                CURRENT_MTD = model.CURRENT_MTD,
                DROPWEEK = !string.IsNullOrWhiteSpace(model.DROPWEEK) ? int.Parse(model.DROPWEEK) : 0,
                DROPDAY = !string.IsNullOrWhiteSpace(model.DROPDAY) ? int.Parse(model.DROPDAY) : 0,
                REMARK = model.REMARK,
                MSORT = model.MSORT,
                IS_DUPLICATE = model.MSORT == "1" ? false : true,
                MONDAY = !string.IsNullOrWhiteSpace(model.MONDAY) ? true : false,
                TUESDAY = !string.IsNullOrWhiteSpace(model.TUESDAY) ? true : false,
                WEDNESDAY = !string.IsNullOrWhiteSpace(model.WEDNESDAY) ? true : false,
                THURSDAY = !string.IsNullOrWhiteSpace(model.THURSDAY) ? true : false,
                FRIDAY = !string.IsNullOrWhiteSpace(model.FRIDAY) ? true : false,
                SATURDAY = !string.IsNullOrWhiteSpace(model.SATURDAY) ? true : false,
                SUNDAY = !string.IsNullOrWhiteSpace(model.SUNDAY) ? true : false,
                SALE_LAST_WEEK = !string.IsNullOrWhiteSpace(model.SALE_LAST_WEEK) ? double.Parse(model.SALE_LAST_WEEK) : 0,
                SALE_LAST_WEEK_END = !string.IsNullOrWhiteSpace(model.SALE_LAST_WEEK_END) ? double.Parse(model.SALE_LAST_WEEK_END) : 0,
                GETPLAN_DETAIL = model.GETPLAN_DETAIL.Select(x => PlanningDetailModeltoModel(x, model.ORGANIZATION_CODE, model.ROUTE_CODE , isCart)).ToList()
            };
        }
    }

   
}
