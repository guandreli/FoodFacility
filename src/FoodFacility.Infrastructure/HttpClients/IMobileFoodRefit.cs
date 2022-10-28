using Refit;
namespace FoodFacility.Infrastructure.HttpClients
{
    public interface IMobileFoodRefit
    {
        [Get("")]
        Task<List<FacilitiesResponse>> GetFoodFacilitiesByNameAsync(string applicant);

        [Get("")]
        Task<List<FacilitiesResponse>> GetFoodFacilitiesAsync();
    }
}
