using FoodFacility.Domain.Interfaces.Services;
using FoodFacility.Infrastructure.HttpClients;

namespace FoodFacility.Infrastructure.Services
{
    public class FacilitiesService : IFacilitiesService
    {
        private readonly IMobileFoodRefit _mobileFoodRefit;

        public FacilitiesService(IMobileFoodRefit mobileFoodRefit)
        {
            _mobileFoodRefit = mobileFoodRefit;
        }

        public async Task<List<FacilitiesResponse>> GetFacilitiesByNameAsync(string facilityName, string status)
        {
            try
            {
                var teste = await _mobileFoodRefit.GetFoodFacilitiesByNameAsync(facilityName);
                if (status != null && !string.IsNullOrEmpty(status))
                {
                    return teste.Where(x => x.Status == status).ToList();
                }
                return teste;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
