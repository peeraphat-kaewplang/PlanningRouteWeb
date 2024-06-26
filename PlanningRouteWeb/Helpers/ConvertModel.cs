using Microsoft.Extensions.Hosting;
using PlanningRouteWeb.Models;

namespace PlanningRouteWeb.Helpers
{
    public static class ConvertModel
    {
        public static Target2 TargetModelToTarget2Model(Target model)
        {
            return new Target2
            {
                VALUE_PER_DAY = !string.IsNullOrWhiteSpace(model.VALUE_PER_DAY) ? int.Parse(model.VALUE_PER_DAY) : 0,
                VALUE_PER_MONTH = !string.IsNullOrWhiteSpace(model.VALUE_PER_MONTH) ? int.Parse(model.VALUE_PER_MONTH) : 0,
                DROP_PER_DAY = !string.IsNullOrWhiteSpace(model.DROP_PER_DAY) ? int.Parse(model.DROP_PER_DAY) : 0,
                SYSTEMCART = !string.IsNullOrWhiteSpace(model.BASKET_SYSTEM) ? model.BASKET_SYSTEM == "1" ? true : false : false
            };
        }
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

        //public static PlanningDetail2 PlanningDetailModeltoModel(PlanningDetail model, DateTime date ,int addDay)
        //{
        //    return new PlanningDetail2
        //    {
        //        CALENDAR_DATE = model.CALENDAR_DATE,
        //        STATUS_ORIGINAL = model.STATUS_ORIGINAL,
        //        //STATUS_MANUAL = true,
        //        STATUS_MANUAL = !string.IsNullOrWhiteSpace(model.STATUS_MANUAL) ? model.STATUS_MANUAL == "Y" ? true : false : false,
        //        DOC_TYPE = model.DOC_TYPE,
        //        SALETOTAL = !string.IsNullOrWhiteSpace(model.SALETOTAL) ? double.Parse(model.SALETOTAL) : 0,
        //        RANK = !string.IsNullOrWhiteSpace(model.RANK) ? int.Parse(model.RANK) : null,
        //        IsCurrent = DateTime.ParseExact(model.CALENDAR_DATE, "dd/MM/yyyy", null).CheckDateInCurrentWeek(date , addDay),
        //        MAX_DROP = model.MAX_DROP,
        //        AMOUNT = !string.IsNullOrWhiteSpace(model.AMOUNT) ? double.Parse(model.AMOUNT) : 0,
        //        HOLIDAY = model.HOLIDAY,
        //        MACHINE_CODE = model.MACHINE_CODE,
        //        CHANGEPRODUCT = model.CHANGEPRODUCT,
        //        REQUISITION = model.REQUISITION
        //    };
        //}

        public static Group2 Group2ModelToModel(Group2 model, bool genRank)
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
                GETPLAN_DETAIL = model.GETPLAN_DETAIL.Select(x => NewPlanningDetail2(x, genRank)).ToList()
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

        //public static PlanningMasterData2 PlanningMasterDataModeltoExcel(PlanningMasterData model, DateTime date , int addDay)
        //{
        //    var data = new PlanningMasterData2
        //    {
        //        YEARMONTH = model.YEARMONTH,
        //        ORGANIZATION_CODE = model.ORGANIZATION_CODE,
        //        ROUTE_CODE = model.ROUTE_CODE,
        //        ROUTE_NAME = model.ROUTE_NAME,
        //        CUSTOMER_CODE = model.CUSTOMER_CODE,
        //        CUSTOMER_NAME = model.CUSTOMER_NAME,
        //        LOCATION_CODE = model.LOCATION_CODE,
        //        LOCATION_NAME = model.LOCATION_NAME,
        //        MACHINE_CODE = model.MACHINE_CODE,
        //        MACHINE_MODEL = model.MACHINE_MODEL,
        //        CHANGE_ACTION = model.CHANGE_ACTION,
        //        TOTAL_FEE = model.TOTAL_FEE,
        //        BEFORE_SALE = model.BEFORE_SALE,
        //        BEFORE_MTD = model.BEFORE_MTD,
        //        CURRENT_MTD = model.CURRENT_MTD,
        //        DROPWEEK = !string.IsNullOrWhiteSpace(model.DROPWEEK) ? int.Parse(model.DROPWEEK) : 0,
        //        DROPDAY = !string.IsNullOrWhiteSpace(model.DROPDAY) ? int.Parse(model.DROPDAY) : 0,
        //        REMARK = model.REMARK,
        //        MSORT = model.MSORT,
        //        IS_DUPLICATE = model.MSORT == "1" ? false : true,
        //        MONDAY = !string.IsNullOrWhiteSpace(model.MONDAY) ? true : false,
        //        TUESDAY = !string.IsNullOrWhiteSpace(model.TUESDAY) ? true : false,
        //        WEDNESDAY = !string.IsNullOrWhiteSpace(model.WEDNESDAY) ? true : false,
        //        THURSDAY = !string.IsNullOrWhiteSpace(model.THURSDAY) ? true : false,
        //        FRIDAY = !string.IsNullOrWhiteSpace(model.FRIDAY) ? true : false,
        //        SATURDAY = !string.IsNullOrWhiteSpace(model.SATURDAY) ? true : false,
        //        SUNDAY = !string.IsNullOrWhiteSpace(model.SUNDAY) ? true : false,
        //        SALE_LAST_WEEK = !string.IsNullOrWhiteSpace(model.SALE_LAST_WEEK) ? double.Parse(model.SALE_LAST_WEEK) : 0,
        //        SALE_LAST_WEEK_END = !string.IsNullOrWhiteSpace(model.SALE_LAST_WEEK_END) ? double.Parse(model.SALE_LAST_WEEK_END) : 0,
        //        GETPLAN_DETAIL = model.GETPLAN_DETAIL
        //                        .Select(x => PlanningDetailModeltoModel(x, date, addDay))
        //                        .ToList(),
        //    };
        //    return data;
        //}

        //public static PlanningMasterData2 PlanningMasterDataModeltoModel(PlanningMasterData model, DateTime date, IEnumerable<PlanningMasterData> Grp, int addDay)
        //{
        //    var data = new PlanningMasterData2
        //    {
        //        YEARMONTH = model.YEARMONTH,
        //        ORGANIZATION_CODE = model.ORGANIZATION_CODE,
        //        ROUTE_CODE = model.ROUTE_CODE,
        //        ROUTE_NAME = model.ROUTE_NAME,
        //        CUSTOMER_CODE = model.CUSTOMER_CODE,
        //        CUSTOMER_NAME = model.CUSTOMER_NAME,
        //        LOCATION_CODE = model.LOCATION_CODE,
        //        LOCATION_NAME = model.LOCATION_NAME,
        //        MACHINE_CODE = model.MACHINE_CODE,
        //        MACHINE_MODEL = model.MACHINE_MODEL,
        //        CHANGE_ACTION = model.CHANGE_ACTION,
        //        TOTAL_FEE = model.TOTAL_FEE,
        //        BEFORE_SALE = model.BEFORE_SALE,
        //        BEFORE_MTD = model.BEFORE_MTD,
        //        CURRENT_MTD = model.CURRENT_MTD,
        //        DROPWEEK = !string.IsNullOrWhiteSpace(model.DROPWEEK) ? int.Parse(model.DROPWEEK) : 0,
        //        DROPDAY = !string.IsNullOrWhiteSpace(model.DROPDAY) ? int.Parse(model.DROPDAY) : 0,
        //        REMARK = model.REMARK,
        //        MSORT = model.MSORT,
        //        IS_DUPLICATE = model.MSORT == "1" ? false : true,
        //        MONDAY = !string.IsNullOrWhiteSpace(model.MONDAY) ? true : false,
        //        TUESDAY = !string.IsNullOrWhiteSpace(model.TUESDAY) ? true : false,
        //        WEDNESDAY = !string.IsNullOrWhiteSpace(model.WEDNESDAY) ? true : false,
        //        THURSDAY = !string.IsNullOrWhiteSpace(model.THURSDAY) ? true : false,
        //        FRIDAY = !string.IsNullOrWhiteSpace(model.FRIDAY) ? true : false,
        //        SATURDAY = !string.IsNullOrWhiteSpace(model.SATURDAY) ? true : false,
        //        SUNDAY = !string.IsNullOrWhiteSpace(model.SUNDAY) ? true : false,
        //        SALE_LAST_WEEK = !string.IsNullOrWhiteSpace(model.SALE_LAST_WEEK) ? double.Parse(model.SALE_LAST_WEEK) : 0,
        //        SALE_LAST_WEEK_END = !string.IsNullOrWhiteSpace(model.SALE_LAST_WEEK_END) ? double.Parse(model.SALE_LAST_WEEK_END) : 0,
        //        ISONLINE = model.ISONLINE,
        //        IS_LOW_QTY = model.IS_LOW_QTY,
        //        GP = model.GP,
        //        GETPLAN_DETAIL = model.GETPLAN_DETAIL
        //                        .Select(x => PlanningDetailModeltoModel(x, date, addDay))
        //                        .ToList(),
        //        GroupData = Grp
        //                    .Select(x => ConvertModel.PlanningMasterDataModeltoModel2(x, date, addDay))
        //                    .OrderBy(x => int.Parse(x.MSORT))
        //                    .ToList(),
        //        Week1 = model.Week1,
        //        Week2 = model.Week2,
        //    };
        //    return data;
        //}

        //public static Group2 PlanningMasterDataModeltoModel2(PlanningMasterData model, DateTime date , int addDay)
        //{

        //    return new Group2
        //    {
        //        YEARMONTH = model.YEARMONTH,
        //        ORGANIZATION_CODE = model.ORGANIZATION_CODE,
        //        ROUTE_CODE = model.ROUTE_CODE,
        //        ROUTE_NAME = model.ROUTE_NAME,
        //        CUSTOMER_CODE = model.CUSTOMER_CODE,
        //        CUSTOMER_NAME = model.CUSTOMER_NAME,
        //        LOCATION_CODE = model.LOCATION_CODE,
        //        LOCATION_NAME = model.LOCATION_NAME,
        //        MACHINE_CODE = model.MACHINE_CODE,
        //        MACHINE_MODEL = model.MACHINE_MODEL,
        //        CHANGE_ACTION = model.MACHINE_CODE == "19785" ? "C" : "",
        //        TOTAL_FEE = model.TOTAL_FEE,
        //        BEFORE_SALE = model.BEFORE_SALE,
        //        BEFORE_MTD = model.BEFORE_MTD,
        //        CURRENT_MTD = model.CURRENT_MTD,
        //        DROPWEEK = !string.IsNullOrWhiteSpace(model.DROPWEEK) ? int.Parse(model.DROPWEEK) : 0,
        //        DROPDAY = !string.IsNullOrWhiteSpace(model.DROPDAY) ? int.Parse(model.DROPDAY) : 0,
        //        REMARK = model.REMARK,
        //        MSORT = model.MSORT,
        //        IS_DUPLICATE = model.MSORT == "1" ? false : true,
        //        MONDAY = !string.IsNullOrWhiteSpace(model.MONDAY) ? true : false,
        //        TUESDAY = !string.IsNullOrWhiteSpace(model.TUESDAY) ? true : false,
        //        WEDNESDAY = !string.IsNullOrWhiteSpace(model.WEDNESDAY) ? true : false,
        //        THURSDAY = !string.IsNullOrWhiteSpace(model.THURSDAY) ? true : false,
        //        FRIDAY = !string.IsNullOrWhiteSpace(model.FRIDAY) ? true : false,
        //        SATURDAY = !string.IsNullOrWhiteSpace(model.SATURDAY) ? true : false,
        //        SUNDAY = !string.IsNullOrWhiteSpace(model.SUNDAY) ? true : false,
        //        SALE_LAST_WEEK = !string.IsNullOrWhiteSpace(model.SALE_LAST_WEEK) ? double.Parse(model.SALE_LAST_WEEK) : 0,
        //        SALE_LAST_WEEK_END = !string.IsNullOrWhiteSpace(model.SALE_LAST_WEEK_END) ? double.Parse(model.SALE_LAST_WEEK_END) : 0,
        //        GETPLAN_DETAIL = model.GETPLAN_DETAIL
        //                        .Select(x => PlanningDetailModeltoModel(x, date , addDay))
        //                        .ToList()
        //    };
        //}
        public static PlanningDetail2 NewPlanningDetail2(PlanningDetail2 model, bool genRank = false)
        {
            return new PlanningDetail2
            {
                CALENDAR_DATE = model.CALENDAR_DATE,
                STATUS_ORIGINAL = model.STATUS_ORIGINAL,
                STATUS_MANUAL = model.STATUS_MANUAL,
                DOC_TYPE = model.DOC_TYPE,
                SALETOTAL = model.SALETOTAL,
                RANK = !genRank ? model.RANK : null,
                HOLIDAY = model.HOLIDAY,
                IsCurrent = model.IsCurrent,
                MACHINE_CODE = model.MACHINE_CODE,
                CHANGEPRODUCT = model.CHANGEPRODUCT,
                MAX_DROP = model.MAX_DROP,
                AMOUNT = model.AMOUNT,
            };
        }
        public static PlanningMasterData2 PlanningMasterData2ViewModel(Group2 model)
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

        public static ChangeProductDetail2 ChangeProductDetailModal(ChangeProductDetail model , bool isStatusChange = false)
        {
            return new ChangeProductDetail2
            {
                MACHINE_CODE = model.MACHINE_CODE,
                RAWPRODUCTCODE = model.RAWPRODUCTCODE,
                PRODUCT_CODE = model.PRODUCT_CODE,
                PRODUCT_NAME = model.PRODUCT_NAME,
                SLOT_NO = int.Parse(model.SLOT_NO),
                SLOT_INSTALLPRICE = !string.IsNullOrWhiteSpace(model.SLOT_INSTALLPRICE) ? double.Parse(model.SLOT_INSTALLPRICE) : 0,
                SLOT_REALPRICE = !string.IsNullOrWhiteSpace(model.SLOT_REALPRICE) ? double.Parse(model.SLOT_REALPRICE) : 0,
                SlotRealPriceOld = !string.IsNullOrWhiteSpace(model.SLOT_REALPRICE) ? double.Parse(model.SLOT_REALPRICE) : 0,
                SlotRealPriceInit = !string.IsNullOrWhiteSpace(model.SLOT_REALPRICE) ? double.Parse(model.SLOT_REALPRICE) : 0,
                SLOT_CONTRACT_PRICE = !string.IsNullOrWhiteSpace(model.SLOT_CONTRACT_PRICE) ? double.Parse(model.SLOT_CONTRACT_PRICE) : 0,
                SLOTSTATUS = !string.IsNullOrWhiteSpace(model.SLOTSTATUS) ? model.SLOTSTATUS == "1" ? true : false : false,
                SALEPRICE = !string.IsNullOrWhiteSpace(model.SALEPRICE) ? double.Parse(model.SALEPRICE) : 0,
                SALETOTAL = !string.IsNullOrWhiteSpace(model.SALETOTAL) ? model.SALETOTAL : "0",
                LOADIN = !string.IsNullOrWhiteSpace(model.LOADIN) ? int.Parse(model.LOADIN) : 0,
                IsStatusChange = isStatusChange,
                STATUSCHANGE = !string.IsNullOrWhiteSpace(model.STATUSCHANGE) ? model.STATUSCHANGE == "1" || model.STATUSCHANGE == "2" ? true : false : false,
                IsAddSlot = !string.IsNullOrWhiteSpace(model.STATUSCHANGE) ? model.STATUSCHANGE == "2" ? true : false : false,
                IsSave = true,
                COSTSALEPRICE = !string.IsNullOrWhiteSpace(model.COSTSALEPRICE) ? double.Parse(model.COSTSALEPRICE) : 0,
                Cost = 11.00,
                QTY = !string.IsNullOrWhiteSpace(model.QTY) ? int.Parse(model.QTY) : 0,
            };
        }

        public static SaveChangeProductData SaveChangeProductDataModel(ChangeProductDetail2 model)
        {
            var status = model.IsAddSlot ? "2" : model.STATUSCHANGE ? "1" : "0";
            return new SaveChangeProductData
            {
                MACHINE_CODE = model.MACHINE_CODE,
                RAWPRODUCTCODE = model.RAWPRODUCTCODE,
                PRODUCT_CODE = model.PRODUCT_CODE,
                PRODUCT_NAME = model.PRODUCT_NAME,
                SLOT_NO = model.SLOT_NO.ToString(),
                SLOT_INSTALLPRICE = model.SLOT_INSTALLPRICE.ToString(),
                SLOT_REALPRICE = model.SLOT_REALPRICE.ToString(),
                SLOT_CONTRACT_PRICE = model.SLOT_CONTRACT_PRICE.ToString(),
                SLOTSTATUS = model.SLOTSTATUS ? "1" : "0",
                LOADIN = model.LOADIN.ToString(),
                STATUSCHANGE =status
            };
        }

        public static BestProduct2 BestProductToBestProduct2(BestProduct model)
        {
            return new BestProduct2
            {
                PRODUCT_CODE = model.PRODUCT_CODE,
                PRODUCT_NAME = model.PRODUCT_NAME,
                TOTALSLOT = !string.IsNullOrWhiteSpace(model.TOTALSLOT) ? int.Parse(model.TOTALSLOT) : 0,
                SALEPRICE = !string.IsNullOrWhiteSpace(model.SALEPRICE) ? double.Parse(model.SALEPRICE) : 0,
                INSTALLPRICE = !string.IsNullOrWhiteSpace(model.INSTALLPRICE) ? double.Parse(model.INSTALLPRICE) : 0,
                DIFFPRICE = !string.IsNullOrWhiteSpace(model.DIFFPRICE) ? double.Parse(model.DIFFPRICE) : 0,
                DURATION = !string.IsNullOrWhiteSpace(model.DURATION) ? int.Parse(model.DURATION) : 0,
                QTY = !string.IsNullOrWhiteSpace(model.QTY) ? int.Parse(model.QTY) : 0,
            };
        }   
    }
}