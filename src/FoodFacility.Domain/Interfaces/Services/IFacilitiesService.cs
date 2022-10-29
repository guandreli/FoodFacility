namespace FoodFacility.Domain.Interfaces.Services
{
    public interface IFacilitiesService
    {
        Task<List<FacilitiesResponse>> GetFacilitiesByAddressAsync(string facilityAddress);
        Task<List<FacilitiesResponse>> GetFacilitiesByNameAsync(string facilityName, string status);
    }
}
