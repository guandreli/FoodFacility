namespace FoodFacility.Infrastructure.Services
{
    public class FacilitiesService : IFacilitiesService
    {
        private readonly IMobileFoodRefit _mobileFoodRefit;

        public FacilitiesService(IMobileFoodRefit mobileFoodRefit)
        {
            _mobileFoodRefit = mobileFoodRefit;
        }

        public async Task<List<FacilitiesResponse>> GetFacilitiesByAddressAsync(string facilityAddress)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(facilityAddress))
                    throw new ArgumentNullException("The Address field is required.");

                var facilities = await _mobileFoodRefit.GetFoodFacilitiesAsync();

                var result = new List<FacilitiesResponse>();
                foreach (var facility in facilities)
                {
                    if (facility.Address.ToUpper().Contains(facilityAddress.ToUpper()))
                        result.Add(facility);
                }

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<FacilitiesResponse>> GetFacilitiesByNameAsync(string facilityName, string status)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(facilityName))
                    throw new ArgumentNullException("The Facility Name field is required.");

                var facilities = await _mobileFoodRefit.GetFoodFacilitiesByNameAsync(facilityName);
                if (status != null && !string.IsNullOrEmpty(status))
                {
                    return facilities.Where(x => x.Status == status).ToList();
                }
                return facilities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
