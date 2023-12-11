using PlanningRouteWeb.Models;

namespace PlanningRouteWeb.Interfaces
{
    public interface IBestProduct
    {
        Task<BestProductResponse> GetBestProduct(BestProductRequest body);
    }
}
