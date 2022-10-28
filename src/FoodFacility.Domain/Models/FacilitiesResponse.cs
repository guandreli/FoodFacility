namespace FoodFacility.Domain.Models
{
    public class FacilitiesResponse
    {
        public string Applicant { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
