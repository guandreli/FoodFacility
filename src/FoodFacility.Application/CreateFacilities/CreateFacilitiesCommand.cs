namespace FoodFacility.Application.CreateFacilities
{
    public class CreateFacilitiesCommand : IRequest<List<CreateFacilitiesResult>>
    {
        /// <summary>
        /// Facility Name
        /// </summary>
        public string? FacilityName { get; set; }

        /// <summary>
        /// Facility status
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Facility address
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Facility latitude
        /// </summary>
        public decimal? Latitude { get; set; }

        /// <summary>
        /// Facility longitude
        /// </summary>
        public decimal? Longitude { get; set; }
    }
}
