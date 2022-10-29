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
            var command = new CreateFacilitiesCommand
            {
                FacilityName = "MOMO INNOVATION LLC",
                Status = null
            };

            var content = new HttpRequestMessage(HttpMethod.Get, $"Facilities?FacilityName={command.FacilityName}");

            var response = await _testFixture.CreateClient().GetAsync(content.RequestUri);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Should_Facility_Select_By_Name_Return_Bad_Request()
        {
            var command = new CreateFacilitiesCommand();

            var content = new HttpRequestMessage(HttpMethod.Get, $"Facilities?FacilityName={command.FacilityName}");

            var response = await _testFixture.CreateClient().GetAsync(content.RequestUri);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Should_Facility_Select_By_Address_Return_Success()
        {
            var command = new CreateFacilitiesCommand
            {
                Address = "SAN"
            };

            var content = new HttpRequestMessage(HttpMethod.Get, $"Facilities?Address={command.Address}");

            var response = await _testFixture.CreateClient().GetAsync(content.RequestUri);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Should_Facility_Select_By_Address_Return_Bad_Request()
        {
            var command = new CreateFacilitiesCommand();

            var content = new HttpRequestMessage(HttpMethod.Get, $"Facilities?Address={command.Address}");

            var response = await _testFixture.CreateClient().GetAsync(content.RequestUri);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
