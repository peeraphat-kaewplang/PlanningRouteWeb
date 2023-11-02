using PlanningRouteWeb.Models;
using PlanningRouteWeb.Services;
using System.Globalization;

namespace PlanningRouteWeb.Helpers
{
    public static class ConvertModel
    {
        public static PlanningDetail PlanningDetail2ModeltoModel(PlanningDetail2 model)
        {
            return new PlanningDetail
            {
                CALENDAR_DATE = model.CALENDAR_DATE,
                STATUS_ORIGINAL = model.STATUS_ORIGINAL,
                STATUS_MANUAL = model.STATUS_MANUAL ? "Y" : "",
                DOC_TYPE = model.DOC_TYPE,
                SALETOTAL = model.SALETOTAL == 0 ? "" : model.SALETOTAL.ToString(),
                RANK = model.RANK == null ? "" : ((int)model.RANK!).ToString(),
                MAX_DROP = model.MAX_DROP,
                AMOUNT = model.AMOUNT.ToString(),
                HOLIDAY = model.HOLIDAY,
                MACHINE_CODE = model.MACHINE_CODE,
                CHANGEPRODUCT = model.CHANGEPRODUCT,
            };
        }
        public static PlanningMasterData PlanningMasterData2ModeltoModel(PlanningMasterData2 model)
        {
            return new PlanningMasterData
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
                DROPWEEK = model.DROPWEEK.ToString(),
                DROPDAY = model.DROPDAY.ToString(),
                REMARK = model.REMARK,
                MSORT = model.MSORT,
                SALE_LAST_WEEK = model.SALE_LAST_WEEK.ToString(),
                SALE_LAST_WEEK_END = model.SALE_LAST_WEEK_END.ToString(),
                MONDAY = model.MONDAY ? "Y" : "",
                TUESDAY = model.TUESDAY ? "Y" : "",
                WEDNESDAY = model.WEDNESDAY ? "Y" : "",
                THURSDAY = model.THURSDAY ? "Y" : "",
                FRIDAY = model.FRIDAY ? "Y" : "",
                SATURDAY = model.SATURDAY ? "Y" : "",
                SUNDAY = model.SUNDAY ? "Y" : "",
                GETPLAN_DETAIL = model.GETPLAN_DETAIL
                                .Select(x => PlanningDetail2ModeltoModel(x)).ToList()
            };
        }

        public static PlanningMasterSave PlanningMasterData2ModeltoSave(PlanningMasterData2 model)
        {
            return new PlanningMasterSave
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
                DROPWEEK = model.DROPWEEK.ToString(),
                DROPDAY = model.DROPDAY.ToString(),
                REMARK = model.REMARK,
                MSORT = model.MSORT,
                SALE_LAST_WEEK = model.SALE_LAST_WEEK.ToString(),
                SALE_LAST_WEEK_END = model.SALE_LAST_WEEK_END.ToString(),
                MONDAY = model.MONDAY ? "Y" : "",
                TUESDAY = model.TUESDAY ? "Y" : "",
                WEDNESDAY = model.WEDNESDAY ? "Y" : "",
                THURSDAY = model.THURSDAY ? "Y" : "",
                FRIDAY = model.FRIDAY ? "Y" : "",
                SATURDAY = model.SATURDAY ? "Y" : "",
                SUNDAY = model.SUNDAY ? "Y" : "",
                SAVEPLAN_detail = model.GETPLAN_DETAIL
                                //.Where(x => int.Parse(x.CALENDAR_DATE.Split("/")[1]) == DateTime.Parse(DateTime.Now.ToStringDate()).Month)
                                .Select(x => PlanningDetail2ModeltoModel(x)).ToList()
            };
        }

        public static PlanningDetail2 PlanningDetailModeltoModel(PlanningDetail model, int addDay)
        {
            return new PlanningDetail2
            {
                CALENDAR_DATE = model.CALENDAR_DATE,
                STATUS_ORIGINAL = model.STATUS_ORIGINAL,
                STATUS_MANUAL = !string.IsNullOrWhiteSpace(model.STATUS_MANUAL) ? true : model.DOC_TYPE == "1" ? true : false,
                DOC_TYPE = model.DOC_TYPE,
                SALETOTAL = !string.IsNullOrWhiteSpace(model.SALETOTAL) ? double.Parse(model.SALETOTAL) : 0,
                RANK = !string.IsNullOrWhiteSpace(model.RANK) ? int.Parse(model.RANK) : null,
                IsCurrent = DateTime.ParseExact(model.CALENDAR_DATE, "dd/MM/yyyy", null).CheckDateInCurrentWeek(addDay),
                MAX_DROP = model.MAX_DROP,
                AMOUNT = !string.IsNullOrWhiteSpace(model.AMOUNT) ? double.Parse(model.AMOUNT) : 0,
                HOLIDAY = model.HOLIDAY,
                MACHINE_CODE = model.MACHINE_CODE,
                CHANGEPRODUCT = model.CHANGEPRODUCT,
            };
        }

        public static Group2 Group2ModelToModel(Group2 model)
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
                CHANGE_ACTION = model.CHANGE_ACTION,
                TOTAL_FEE = model.TOTAL_FEE,
                BEFORE_SALE = model.BEFORE_SALE,
                BEFORE_MTD = model.BEFORE_MTD,
                CURRENT_MTD = model.CURRENT_MTD,
                DROPWEEK = model.DROPWEEK,
                DROPDAY = model.DROPDAY,
                REMARK = model.REMARK,
                MSORT = model.MSORT,
                MONDAY = model.MONDAY,
                TUESDAY = model.TUESDAY,
                WEDNESDAY = model.WEDNESDAY,
                THURSDAY = model.THURSDAY,
                FRIDAY = model.FRIDAY,
                SATURDAY = model.SATURDAY,
                SUNDAY = model.SUNDAY,
                IS_DUPLICATE = model.IS_DUPLICATE,
                SALE_LAST_WEEK = model.SALE_LAST_WEEK,
                GETPLAN_DETAIL = model.GETPLAN_DETAIL.Select(x => NewPlanningDetail2(x)).ToList()
            };
        }

        public static PlanningMasterData2 Group2ModelToPlanningMasterData2(Group2 model)
        {
            return new PlanningMasterData2
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
                DROPWEEK = model.DROPWEEK,
                DROPDAY = model.DROPDAY,
                REMARK = model.REMARK,
                MSORT = model.MSORT,
                MONDAY = model.MONDAY,
                TUESDAY = model.TUESDAY,
                WEDNESDAY = model.WEDNESDAY,
                THURSDAY = model.THURSDAY,
                FRIDAY = model.FRIDAY,
                SATURDAY = model.SATURDAY,
                SUNDAY = model.SUNDAY,
                IS_DUPLICATE = model.IS_DUPLICATE,
                SALE_LAST_WEEK = model.SALE_LAST_WEEK,
                GETPLAN_DETAIL = model.GETPLAN_DETAIL.Select(x => NewPlanningDetail2(x)).ToList()
            };
        }

        public static PlanningMasterData2 PlanningMasterDataModeltoModel(PlanningMasterData model, int addDay , IEnumerable<PlanningMasterData> Grp)
        {
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
                GETPLAN_DETAIL = model.GETPLAN_DETAIL
                                .Select(x => PlanningDetailModeltoModel(x, addDay))
                                .ToList(),
                GroupData = Grp
                            .Select(x => ConvertModel.PlanningMasterDataModeltoModel2(x, addDay))
                            .OrderBy(x => int.Parse(x.MSORT))
                            .ToList(),
            };

            return data;
        }

        public static Group2 PlanningMasterDataModeltoModel2(PlanningMasterData model, int addDay)
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
                GETPLAN_DETAIL = model.GETPLAN_DETAIL
                                .Select(x => PlanningDetailModeltoModel(x, addDay))
                                .ToList()
            };
        }
        public static PlanningDetail2 NewPlanningDetail2(PlanningDetail2 model)
        {
            return new PlanningDetail2
            {
                CALENDAR_DATE = model.CALENDAR_DATE,
                STATUS_ORIGINAL = model.STATUS_ORIGINAL,
                STATUS_MANUAL = model.STATUS_MANUAL,
                DOC_TYPE = model.DOC_TYPE,
                SALETOTAL = model.SALETOTAL,
                RANK = null,
                HOLIDAY = model.HOLIDAY,
                IsCurrent = model.IsCurrent,
                MACHINE_CODE = model.MACHINE_CODE,
                CHANGEPRODUCT = model.CHANGEPRODUCT,
                MAX_DROP = model.MAX_DROP,
                AMOUNT = model.AMOUNT,
            };
        }
        public static PlanningMasterData2 PlanningMasterData2ViewModel(PlanningMasterData2 model)
        {
            return new PlanningMasterData2
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
                DROPWEEK = model.DROPWEEK,
                DROPDAY = model.DROPDAY,
                REMARK = model.REMARK,
                MSORT = model.MSORT,
                MONDAY = model.MONDAY,
                TUESDAY = model.TUESDAY,
                WEDNESDAY = model.WEDNESDAY,
                THURSDAY = model.THURSDAY,
                FRIDAY = model.FRIDAY,
                SATURDAY = model.SATURDAY,
                SUNDAY = model.SUNDAY,
                IS_DUPLICATE = model.IS_DUPLICATE,
                SALE_LAST_WEEK = model.SALE_LAST_WEEK,
                GETPLAN_DETAIL = model.GETPLAN_DETAIL.Select(x => NewPlanningDetail2(x)).ToList()
            };
        }

        public static ChangeProductDetail2 ChangeProductDetailModal(ChangeProductDetail model)
        {
            return new ChangeProductDetail2
            {
                MACHINE_CODE = model.MACHINE_CODE,
                RAWPRODUCTCODE = model.RAWPRODUCTCODE,
                PRODUCT_CODE = model.PRODUCT_CODE,
                PRODUCT_NAME = model.PRODUCT_NAME,
                SLOT_NO = int.Parse(model.SLOT_NO),
                SLOT_INSTALLPRICE = model.SLOT_INSTALLPRICE,
                SLOT_REALPRICE = !string.IsNullOrWhiteSpace(model.SLOT_REALPRICE) ? int.Parse(model.SLOT_REALPRICE) : 0,
                SLOT_CONTRACT_PRICE = model.SLOT_CONTRACT_PRICE,
                SLOTSTATUS = !string.IsNullOrWhiteSpace(model.SLOTSTATUS) ? model.SLOTSTATUS == "1" ? true : false : false,
                SALEPRICE = model.SALEPRICE,
                SALETOTAL = model.SALETOTAL,
                LOADIN = !string.IsNullOrWhiteSpace(model.LOADIN) ? int.Parse(model.LOADIN) : 0,
                STATUSCHANGE = !string.IsNullOrWhiteSpace(model.STATUSCHANGE) ? model.STATUSCHANGE == "1" ? true : false : false,
                IsSubRow = !string.IsNullOrWhiteSpace(model.STATUSCHANGE) ? model.STATUSCHANGE == "1" ? true : false : false,
            };
        }


        public static SaveChangeProductData SaveChangeProductDataModel(ChangeProductDetail2 model)
        {
            return new SaveChangeProductData
            {
                MACHINE_CODE = model.MACHINE_CODE,
                RAWPRODUCTCODE = model.RAWPRODUCTCODE,
                PRODUCT_CODE = model.PRODUCT_CODE,
                PRODUCT_NAME = model.PRODUCT_NAME,
                SLOT_NO = model.SLOT_NO.ToString(),
                SLOT_INSTALLPRICE = model.SLOT_INSTALLPRICE,
                SLOT_REALPRICE = model.SLOT_REALPRICE.ToString(),
                SLOT_CONTRACT_PRICE = model.SLOT_CONTRACT_PRICE,
                SLOTSTATUS = model.SLOTSTATUS ? "1" : "0",
                LOADIN = model.LOADIN.ToString(),
                STATUSCHANGE = model.STATUSCHANGE ? "1" : "0"
            };
        }
    }
}