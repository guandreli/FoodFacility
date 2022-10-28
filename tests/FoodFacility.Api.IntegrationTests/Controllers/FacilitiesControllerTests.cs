using FoodFacility.Application.CreateFacilities;

namespace FoodFacility.Api.IntegrationTests.Controllers
{
    public class FacilitiesControllerTests
    {
        private readonly TestFixture _testFixture;
        public FacilitiesControllerTests()
        {
            _testFixture = new TestFixture();
        }

        [Fact]
        public async Task Should_Facility_Select_By_Name_Return_Success()
        {
            var command = new CreateSelectByNameCommand
            {
                FacilityName = "MOMO INNOVATION LLC",
                Status = null
            };

            var content = new HttpRequestMessage(HttpMethod.Get, $"Facilities/SearchByName?FacilityName={command.FacilityName}");

            var response = await _testFixture.CreateClient().GetAsync(content.RequestUri);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Should_Facility_Select_By_Name_Return_Bad_Request()
        {
            var command = new CreateSelectByNameCommand();

            var content = new HttpRequestMessage(HttpMethod.Get, $"Facilities/SearchByName?FacilityName={command.FacilityName}");

            var response = await _testFixture.CreateClient().GetAsync(content.RequestUri);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Should_Facility_Select_By_Address_Return_Success()
        {
            var command = new CreateSelectByAddressCommand
            {
                Address = "SAN"
            };

            var content = new HttpRequestMessage(HttpMethod.Get, $"Facilities/SearchByAdress?Address={command.Address}");

            var response = await _testFixture.CreateClient().GetAsync(content.RequestUri);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Should_Facility_Select_By_Address_Return_Bad_Request()
        {
            var command = new CreateSelectByAddressCommand();

            var content = new HttpRequestMessage(HttpMethod.Get, $"Facilities/SearchByAdress?Address={command.Address}");

            var response = await _testFixture.CreateClient().GetAsync(content.RequestUri);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
