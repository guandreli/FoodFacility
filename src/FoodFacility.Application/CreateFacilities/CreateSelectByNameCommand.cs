namespace FoodFacility.Application.CreateFacilities
{
    public class CreateSelectByNameCommand : IRequest<List<CreateFacilitiesResult>>
    {
        /// <summary>
        /// Facility Name
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// Facility status
        /// </summary>
        public string? Status { get; set; }
    }
}
