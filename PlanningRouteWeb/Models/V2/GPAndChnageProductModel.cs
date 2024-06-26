using PlanningRouteWeb.Helpers;

namespace PlanningRouteWeb.Models.V2
{
    public class ParameterChangeProduct
    {
        public string ORG { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Machine { get; set; } = string.Empty;
        public string ChangeDate { get; set; } = string.Empty;
    }

    public class ChangeProductRes : HttpResponse
    {
        public ChangeProductData Data { get; set; } = new();
    }
    public class ChangeProductData
    {
        public ChangeProductHeader Header { get; set; } = new();
        public List<ChangeProductDetail> Detail { get; set; } = new();
        public List<GPModelData> GP { get; set; } = new();
    }
    public class ChangeProductHeader
    {
        public string MACHINE_CODE { get; set; } = string.Empty;
        public string ORGANIZATION_CODE {  get; set; } = string.Empty;
        public string MACHINE_TYPE {  get; set; } = string.Empty;
        public string MACHINE_TYPE_NAME {  get; set; } = string.Empty;
        public string MACHINE_MODEL { get; set; } = string.Empty;
        public string TYPE_METER { get; set; } = string.Empty;
        public string TYPE_LOAD { get; set; } = string.Empty;
        public string ISONLINE { get; set; } = string.Empty;
        public string STATUS_SORT { get; set; } = string.Empty;
    }
    public class ChangeProductDetail
    {
        public string MACHINE_CODE { get; set; } = string.Empty;
        public string RAWPRODUCTCODE { get; set; } = string.Empty;
        public string PRODUCT_CODE { get; set; } = string.Empty;
        public string PRODUCT_NAME { get; set; } = string.Empty;
        public string SLOT_NO { get; set; } = string.Empty;
        public string SLOT_INSTALLPRICE { get; set; } = string.Empty;
        public string SLOT_REALPRICE { get; set; } = string.Empty;
        public string SLOT_CONTRACT_PRICE { get; set; } = string.Empty;
        public string SLOTSTATUS { get; set; } = string.Empty;
        public string LOADIN { get; set; } = string.Empty;
        public string STATUSCHANGE { get; set; } = string.Empty;
        public double S_COSTPRICE { get; set; } 

    }
    
    public class ChangeProductDetailView
    {
        public string MACHINE_CODE { get; set; } = string.Empty;
        public string RAWPRODUCTCODE { get; set; } = string.Empty;
        public string PRODUCT_CODE { get; set; } = string.Empty;
        public string PRODUCT_NAME { get; set; } = string.Empty;
        public int SLOT_NO { get; set; }
        public double SLOT_INSTALLPRICE { get; set; } 
        public double SLOT_REALPRICE { get; set; } 
        public double SLOT_CONTRACT_PRICE { get; set; } 
        public bool SLOTSTATUS { get; set; }
        public int LOADIN { get; set; }
        public bool STATUSCHANGE { get; set; }
        public double S_COSTPRICE { get; set; }
        public double S_SALEPRICE { get; set; }
        public double GP { get; set; }
        public double QTY { get; set; }
        public static ChangeProductDetailView CopyModel(ChangeProductDetailView model)
        {
            return new ChangeProductDetailView
            {
                MACHINE_CODE = model.MACHINE_CODE,
                RAWPRODUCTCODE = model.RAWPRODUCTCODE,
                PRODUCT_CODE = model.PRODUCT_CODE,
                PRODUCT_NAME = model.PRODUCT_NAME,
                SLOT_NO = model.SLOT_NO,
                SLOT_INSTALLPRICE = model.SLOT_INSTALLPRICE,
                SLOT_REALPRICE = model.SLOT_REALPRICE,
                SLOT_CONTRACT_PRICE = model.SLOT_CONTRACT_PRICE,
                SLOTSTATUS = model.SLOTSTATUS,
                LOADIN = model.LOADIN,
                STATUSCHANGE = model.STATUSCHANGE,
                S_COSTPRICE = model.S_COSTPRICE,
                GP = model.GP
            };
        }
        public static ChangeProductDetailView ConverModel(ChangeProductDetail model)
        {
            return new ChangeProductDetailView
            {
                MACHINE_CODE = model.MACHINE_CODE,
                RAWPRODUCTCODE = model.RAWPRODUCTCODE,
                PRODUCT_CODE = model.PRODUCT_CODE,
                PRODUCT_NAME = model.PRODUCT_NAME,
                SLOT_NO = int.Parse(model.SLOT_NO),
                SLOT_INSTALLPRICE = Double.Parse(model.SLOT_INSTALLPRICE),
                SLOT_REALPRICE = Double.Parse(model.SLOT_REALPRICE),
                SLOT_CONTRACT_PRICE = Double.Parse(model.SLOT_CONTRACT_PRICE),
                SLOTSTATUS = !string.IsNullOrEmpty(model.SLOTSTATUS) ? model.SLOTSTATUS == "1" ? true : false : false,
                LOADIN = string.IsNullOrEmpty(model.LOADIN) ? 0 : int.Parse(model.LOADIN),
                STATUSCHANGE = !string.IsNullOrEmpty(model.STATUSCHANGE) ? model.STATUSCHANGE == "0" ? false : true : false,
                S_COSTPRICE = model.S_COSTPRICE,
                GP = model.S_COSTPRICE != 0 ? (Double.Parse(model.SLOT_INSTALLPRICE) - model.S_COSTPRICE) / model.S_COSTPRICE * 100 : 0
            };
        }
    }
     

    public class GPModelRes : HttpResponse
    {
        public List<GPModelData> Data { get; set; } = new();
    }
    public class GPModelData
    {
        public string MACHINE_CODE { get; set; } = string.Empty;
        public string RAWPRODUCTCODE { get; set; } = string.Empty;
        public string PRODUCT_CODE { get; set; } = string.Empty;
        public string PRODUCT_NAME { get; set; } = string.Empty;
        public string S_COSTPRICE { get; set; } = string.Empty;
        public string S_SALEPRICE { get; set; } = string.Empty;
        public string S_GP { get; set; } = string.Empty;
        public string SALEPRICE { get; set; } = string.Empty;
        public string GP { get; set; } = string.Empty;
        public string QTY { get; set; } = string.Empty;
        public string SLOT { get; set; } = string.Empty;
        public string QTYSLOT { get; set; } = string.Empty;
        public string QTYTOTAL { get; set; } = string.Empty;
        public string COSTTOTAL { get; set; } = string.Empty;
        public string SALETOTAL { get; set; } = string.Empty;
        public string PROFIT { get; set; } = string.Empty;
        public string WEIGHTGP { get; set; } = string.Empty;
    }

    public class GPModelDataView
    {
        public string PRODUCT_CODE { get; set; } = string.Empty;
        public string PRODUCT_NAME { get; set; } = string.Empty;
        public double S_COSTPRICE { get; set; }
        public double S_SALEPRICE { get; set; }
        public double S_GP { get;set; }
        public double SALEPRICE { get; set; }
        public double GP {  get;set; }
        public double QTY { get; set; }
        public int SLOT { get; set; }
        public double QTYSLOT { get; set; }
        public double QTYTOTAL {  get; set; }
        public double COSTTOTAL { get; set; }
        public double SALETOTAL { get; set; }
        public double PROFIT { get; set; }
        public double WEIGHTGP { get; set; }
        public bool Is_SlotStatus { get; set; }
        public static GPModelDataView CalWeightGP(GPModelDataView model , double profitTotal)
        {
            return new GPModelDataView
            {
                PRODUCT_CODE = model.PRODUCT_CODE,
                PRODUCT_NAME = model.PRODUCT_NAME,
                S_COSTPRICE = model.S_COSTPRICE,
                S_SALEPRICE = model.S_SALEPRICE,
                S_GP = model.S_GP,
                SALEPRICE = model.SALEPRICE,
                GP = model.GP,
                QTY = model.QTY ,
                SLOT = model.SLOT,
                QTYSLOT =   model.QTYSLOT,
                QTYTOTAL = model.QTYTOTAL,
                COSTTOTAL = model.COSTTOTAL,
                SALETOTAL = model.SALETOTAL ,
                PROFIT = model.PROFIT,
                WEIGHTGP = (model.PROFIT / profitTotal) *100,
            };
        }
        public static GPModelDataView ConvertModel(GPModelData model)
        {
           return new GPModelDataView
            {
                PRODUCT_CODE = model.PRODUCT_CODE,
                PRODUCT_NAME = model.PRODUCT_NAME,
                S_COSTPRICE = Double.Parse(model.S_COSTPRICE),
                S_SALEPRICE = Double.Parse(model.S_SALEPRICE),
                S_GP = Double.Parse(model.S_GP),
                SALEPRICE = Double.Parse(model.SALEPRICE),
                GP = Double.Parse(model.GP),
                QTY = Double.Parse(model.QTY),
                SLOT = int.Parse(model.SLOT) == 0 ? 1 : int.Parse(model.SLOT),
                QTYSLOT = Double.Parse(model.QTYSLOT),
                QTYTOTAL = Double.Parse(model.QTYTOTAL),
                COSTTOTAL = Double.Parse(model.COSTTOTAL),
                SALETOTAL = Double.Parse(model.SALETOTAL),
                PROFIT = Double.Parse(model.PROFIT),
                WEIGHTGP = Double.Parse(model.WEIGHTGP),
                Is_SlotStatus = true
           };
        }

        public static GPModelDataView ConvertCalModel(GPModelDataView model)
        {
            return new GPModelDataView
            {
                PRODUCT_CODE = model.PRODUCT_CODE,
                PRODUCT_NAME = model.PRODUCT_NAME,
                S_COSTPRICE = model.S_COSTPRICE,
                S_SALEPRICE = model.S_SALEPRICE,
                S_GP = model.S_COSTPRICE != 0 ? ((model.S_SALEPRICE - model.S_COSTPRICE) / model.S_COSTPRICE) * 100 : ((model.S_SALEPRICE - model.S_COSTPRICE) / model.S_SALEPRICE) * 100,
                SALEPRICE = model.SALEPRICE,
                GP = model.S_COSTPRICE != 0 ? ((model.SALEPRICE - model.S_COSTPRICE) / model.S_COSTPRICE) * 100 : ((model.SALEPRICE - model.S_COSTPRICE) / model.SALEPRICE) * 100,
                QTY = model.QTY,
                SLOT = model.SLOT,
                QTYSLOT = Convert.ToDouble(model.QTY) / Convert.ToDouble(model.SLOT),
                QTYTOTAL = model.QTY / model.SLOT * model.SLOT,
                COSTTOTAL = (model.QTY / model.SLOT * model.SLOT) * model.S_COSTPRICE,
                SALETOTAL = model.SALEPRICE * (model.QTY / model.SLOT * model.SLOT),
                PROFIT = (model.SALEPRICE * (model.QTY / model.SLOT * model.SLOT)) - (model.QTY / model.SLOT * model.SLOT) * model.S_COSTPRICE,
                WEIGHTGP = model.WEIGHTGP,
            };
        }
    }
}
