using FoodFacility.Application.Common.Mappings;

namespace FoodFacility.Application.CreateFacilities
{
    public class CreateSelectByNameResult : IMapFrom<FacilitiesResponse>
    {
        public string Applicant { get; set; }
        public string Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FacilitiesResponse, CreateSelectByNameResult>()
                .ForMember(d => d.Applicant, opt => opt.MapFrom(s => s.Applicant))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status));
        }
    }
}
