namespace PlanningRouteWeb.Models
{
    public class ChangeProductRequest
    {
        public string ORG { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Machine { get; set; } = string.Empty;
        public string ChangeDate { get; set; } = string.Empty;
    }
    
    public class SaveChangeProductRequest : ChangeProductRequest
    {
        public string Cancel { get; set; } = string.Empty;
        public List<SaveChangeProductData> Data { get; set; } = new();
    }

    public class SaveChangeProductData
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
    }
}
