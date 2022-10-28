namespace FoodFacility.Domain.Interfaces.Services
{
    public interface IFacilitiesService
    {
        Task<List<FacilitiesResponse>> GetFacilitiesByNameAsync(string facilityName, string status);
    }
}
