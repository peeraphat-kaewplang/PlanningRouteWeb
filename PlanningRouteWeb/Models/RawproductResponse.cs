namespace PlanningRouteWeb.Models
{
    public class RawproductResponse : HttpResponse
    {
        public List<Rawproduct> Data { get; set; } = new();
    }

    public class Rawproduct
    {
        public string RAWPRODUCTCODE { get; set; } = string.Empty;
        public string RAWPRODUCTNAME { get; set; } = string.Empty;
    }

    public class RawproductDetailResponse : HttpResponse
    {
        public List<RawproductDetail> Data { get; set; } = new();
    }

    public class RawproductDetail
    {
        public string RAWPRODUCTCODE { get; set;} = string.Empty;
        public string PRODUCTCODE { get; set; } = string.Empty;
        public string PRODUCTNAME { get; set; } = string.Empty;
    }

    public class RawproductDetail2Response : HttpResponse
    {
        public List<RawproductDetail2> Data { get; set; } = new();
    }

    public class RawproductDetail2
    {
        public string RAWPRODUCTCODE { get; set; } = string.Empty;
        public string RAWPRODUCTNAME { get; set; } = string.Empty;
        public string PRODUCTCODE { get; set; } = string.Empty;
        public string PRODUCTNAME { get; set; } = string.Empty;
        public string SALEPRICE { get; set; } = string.Empty;
        public string SALETOTAL { get; set; } = string.Empty;
        public string COSTPRICE { get; set; } = string.Empty;
    }
}
