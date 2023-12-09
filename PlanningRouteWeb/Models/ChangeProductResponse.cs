using System.IO;
using System.Net;

namespace PlanningRouteWeb.Models
{

    public class ChangeProductResponse : HttpResponse
    {
        public ChangeProductData Data { get; set; } = new();
    }

    public class ChangeProductData
    {
        public ChangeProductHeader Header { get; set; } = new();
        public List<ChangeProductDetail> Detail { get; set; } = new();
    }

    public class ChangeProductData2
    {
        public ChangeProductHeader Header { get; set; } = new();
        public List<ChangeProductDetail2> Detail { get; set; } = new();
    }

    public class ChangeProductHeader
    {
        public string MACHINE_CODE { get; set; } = string.Empty;
        public string ORGANIZATION_CODE { get; set; } = string.Empty;
        public string MACHINE_TYPE { get; set; } = string.Empty;
        public string MACHINE_TYPE_NAME { get; set; } = string.Empty;
        public string MACHINE_MODEL { get; set; } = string.Empty;
        public string TYPE_METER { get; set; } = string.Empty;
        public string TYPELOAD { get; set; } = string.Empty;
        public string ISONLINE { get; set; } = string.Empty;
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
        public string SALEPRICE { get; set; } = string.Empty;
        public string SALETOTAL { get; set; } = string.Empty;
        public string LOADIN { get; set; } = string.Empty;
        public string STATUSCHANGE { get; set; } = string.Empty;
    }

    public class ChangeProductDetail2 
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
        public double SALEPRICE { get; set; } 
        public string SALETOTAL { get; set; } = string.Empty;
        public int LOADIN { get; set; }
        public bool STATUSCHANGE { get; set; }
        public double SlotRealPriceOld { get; set; }
        public double SlotRealPriceInit { get; set; }
        public bool IsAddSlot { get; set; } // เพิ่ม slot
        public bool IsStatusChange { get; set; } // เปลี่ยน status ที่ UI
        public bool IsSave { get;set; }
        public double? Move { get; set; }
        public bool IsCopy { get; set; }


        public object Clone()
        {
            return new ChangeProductDetail2
            {
                MACHINE_CODE = MACHINE_CODE,
                RAWPRODUCTCODE = RAWPRODUCTCODE,
                PRODUCT_CODE = PRODUCT_CODE,
                PRODUCT_NAME = PRODUCT_NAME,
                SLOT_NO = SLOT_NO,
                SLOT_INSTALLPRICE = SLOT_INSTALLPRICE,
                SLOT_REALPRICE = SLOT_REALPRICE,
                SLOT_CONTRACT_PRICE = SLOT_CONTRACT_PRICE,
                SLOTSTATUS = SLOTSTATUS,
                SALEPRICE = SALEPRICE,
                SALETOTAL = SALETOTAL,
                LOADIN = LOADIN,
                STATUSCHANGE = STATUSCHANGE,
                SlotRealPriceOld = SlotRealPriceOld,
                SlotRealPriceInit = SlotRealPriceInit,
                IsAddSlot = IsAddSlot,
                IsStatusChange = IsStatusChange,
                IsSave = IsSave,
                Move = Move,
                IsCopy = IsCopy,
            };
        }
    }

    public class SaveChangeProductResponse : HttpResponse
    {
        public string Status { get; set; } = string.Empty;
    }

    public class ChangeProductGroup
    {
        public string SLOT_NO { get; set; } = string.Empty;
        public double SLOT_REALPRICE { get; set; } 
        public List<ChangeProductDetail2> Products { get; set; } = new();
        public bool SlotStatus { get; set; } 
        public bool IsAddSlot { get; set; } 
        public bool IsEmptySlot { get; set; }
        
    }
}
