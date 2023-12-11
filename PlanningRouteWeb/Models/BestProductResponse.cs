namespace PlanningRouteWeb.Models
{
    public class BestProductResponse : HttpResponse
    {
        public List<BestProduct> Data { get; set; } = new();
    }

    public class BestProduct
    {
        public string? PRODUCT_CODE { get; set; }
        public string? PRODUCT_NAME { get; set; }
        public string? TOTALSLOT { get; set; }
        public string? SALEPRICE { get; set; }
        public string? INSTALLPRICE { get; set; }
        public string? DIFFPRICE { get; set; }
        public string? DURATION { get; set; }
        public string? QTY { get; set; }
    }

    public class BestProduct2
    {
        public string? PRODUCT_CODE { get; set; }
        public string? PRODUCT_NAME { get; set; }
        public int TOTALSLOT { get; set; }
        public double SALEPRICE { get; set; }
        public double INSTALLPRICE { get; set; }
        public double DIFFPRICE { get; set; }
        public int DURATION { get; set; }
        public int QTY { get; set; }

    }
}
