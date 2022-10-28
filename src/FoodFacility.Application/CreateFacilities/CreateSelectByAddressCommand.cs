namespace FoodFacility.Application.CreateFacilities
{
    public class CreateSelectByAddressCommand : IRequest<List<CreateFacilitiesResult>>
    {
        /// <summary>
        /// Facility address
        /// </summary>
        public string Address { get; set; }
    }
}
