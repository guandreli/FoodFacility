namespace FoodFacility.Application.CreateFacilities
{
    public class CreateSelectByNameCommand : IRequest<List<CreateSelectByNameResult>>
    {
        public string FacilityName { get; set; }
        public string Status { get; set; }
    }
}
