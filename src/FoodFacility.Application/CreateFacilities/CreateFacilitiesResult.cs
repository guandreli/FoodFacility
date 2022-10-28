using FoodFacility.Application.Common.Mappings;

namespace FoodFacility.Application.CreateFacilities
{
    public class CreateFacilitiesResult : IMapFrom<FacilitiesResponse>
    {
        public string Applicant { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FacilitiesResponse, CreateFacilitiesResult>();
        }
    }
}
