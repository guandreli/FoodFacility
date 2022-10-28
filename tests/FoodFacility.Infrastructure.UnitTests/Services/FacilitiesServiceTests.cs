using FoodFacility.Domain.Interfaces.Services;
using FoodFacility.Domain.Models;
using FoodFacility.Infrastructure.HttpClients;
using FoodFacility.Infrastructure.Services;
using Moq;

namespace FoodFacility.Infrastructure.UnitTests.Services
{
    public class FacilitiesServiceTests
    {
        private readonly IFacilitiesService _facilityService;
        private readonly Mock<IMobileFoodRefit> _mobileFoodRefit;

        public FacilitiesServiceTests()
        {
            _mobileFoodRefit = new Mock<IMobileFoodRefit>();
            _facilityService = new FacilitiesService(_mobileFoodRefit.Object);
        }

        [Fact]
        public async Task Should_Select_Facility_Bay_Name_Returns_List_Of_Facilities()
        {
            //arrange
            var facilitiesResponse = FacilitiesList();
            var facilityName = "The Geez Freeze";

            //setup
            var mocRequest = _mobileFoodRefit
                .Setup(s => s.GetFoodFacilitiesByNameAsync(facilityName))
                .ReturnsAsync(facilitiesResponse.Where(x => x.Applicant == facilityName).ToList());

            //act
            var result = await _facilityService.GetFacilitiesByNameAsync(facilityName, null);

            //assert
            Assert.IsType<List<FacilitiesResponse>>(result);
            Assert.NotNull(result);
            Assert.True(result.Count == 1);
        }

        [Fact]
        public async Task Should_Select_Facility_Bay_Name_Returns_Error()
        {
            try
            {
                //act
                var result = await _facilityService.GetFacilitiesByNameAsync(null, null);
            }
            catch (Exception ex)
            {
                //assert
                Assert.NotNull(ex.Message);
                Assert.True(ex.Message == "The Facility Name field is required.");
            }
        }

        [Fact]
        public async Task Should_Select_Facility_Bay_Address_Returns_List_Of_Facilities()
        {
            //arrange
            var facilitiesResponse = FacilitiesList();
            var facilityAddress = "Mar";

            //setup
            var mocRequest = _mobileFoodRefit
                .Setup(s => s.GetFoodFacilitiesAsync())
                .ReturnsAsync(facilitiesResponse);

            //act
            var result = await _facilityService.GetFacilitiesByAddressAsync(facilityAddress);

            //assert
            Assert.IsType<List<FacilitiesResponse>>(result);
            Assert.NotNull(result);
            Assert.True(result.Count == 2);
        }

        [Fact]
        public async Task Should_Select_Facility_Bay_Address_Returns_Error()
        {
            try
            {
                //act
                var result = await _facilityService.GetFacilitiesByAddressAsync(null);
            }
            catch (Exception ex)
            {
                //assert
                Assert.NotNull(ex.Message);
                Assert.True(ex.Message == "The Address field is required.");
            }
        }

        private List<FacilitiesResponse> FacilitiesList()
        {
            return new List<FacilitiesResponse>()
            {
                new FacilitiesResponse
                {
                    Applicant = "The Geez Freeze",
                    Status = "APPROVED",
                    Address = "3750 18TH ST",
                    Latitude = 37.76201920035647M,
                    Longitude = -122.42730642251331M
                },
                new FacilitiesResponse
                {
                    Applicant = "MOMO INNOVATION LLC",
                    Status = "APPROVED",
                    Address = "101 CALIFORNIA ST",
                    Latitude = 37.792948952834664M,
                    Longitude = -122.39809861316652M
                },
                new FacilitiesResponse
                {
                    Applicant = "Treats by the Bay LLC",
                    Status = "APPROVED",
                    Address = "201 02ND ST",
                    Latitude = 37.78680165059711M,
                    Longitude = -122.39787163500326M
                },
                new FacilitiesResponse
                {
                    Applicant = "MOMO INNOVATION LLC",
                    Status = "APPROVED",
                    Address = "1 BUSH ST",
                    Latitude = 37.79092150726921M,
                    Longitude = -122.4001004237385M
                },
                new FacilitiesResponse
                {
                    Applicant = "DO UC US Mobile Catering",
                    Status = "APPROVED",
                    Address = "2590 MARIN ST",
                    Latitude = 37.74837582577795M,
                    Longitude = -122.40320062649582M
                },
                new FacilitiesResponse
                {
                    Applicant = "Treats by the Bay LLC",
                    Status = "EXPIRED",
                    Address = "1 MARKET ST",
                    Latitude = 37.793871507150634M,
                    Longitude = -122.39486523862108M
                },
                new FacilitiesResponse
                {
                    Applicant = "Treats by the Bay LLC",
                    Status = "REQUESTED",
                    Address = "1550 04TH ST",
                    Latitude = 37.769124412168054M,
                    Longitude = -122.39147491124585M
                }
            };
        }
    }
}

