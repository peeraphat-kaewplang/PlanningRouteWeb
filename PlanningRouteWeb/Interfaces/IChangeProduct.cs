using PlanningRouteWeb.Models;

namespace PlanningRouteWeb.Interfaces
{
    public interface IChangeProductService
    {
        Task<ChangeProductData2> GetChangeProduct(ChangeProductRequest body);
        Task<RawproductResponse> GetRawproduct(RawproductRequest body);
        Task<RawproductDetailResponse> GetRawproductDetail(RawproductRequest body);
        Task<RawproductDetail2Response> GetRawproductDetail2(RawproductDetail2Request body);
        Task<SaveChangeProductResponse> SaveChangeProduct(SaveChangeProductRequest body);
    }
}
