using FoodFacility.Application.CreateFacilities;

namespace FoodFacility.Api.UnitTests.Controllers
{
    public class FacilitiesControllerTests
    {
        [Fact]
        public async Task Should_Get_Facilities_By_Name_Command_To_Mediator()
        {
            //arrange
            var mediatorMock = new Mock<IMediator>();
            var facilitiesResult = new List<CreateFacilitiesResult>();
            var command = new CreateSelectByNameCommand
            {
                FacilityName = "Treats by the Bay LLC",
                Status = "APPROVED"
            };

            //act
            mediatorMock.Setup(x => x.Send(command, CancellationToken.None)).ReturnsAsync(facilitiesResult);

            var controller = new FacilitiesController(mediatorMock.Object);
            var result = await controller.GetFacilitiesByName(command);

            //assert
            mediatorMock.VerifyAll();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_Get_Facilities_By_Address_Command_To_Mediator()
        {
            //arrange
            var mediatorMock = new Mock<IMediator>();
            var facilitiesResult = new List<CreateFacilitiesResult>();
            var command = new CreateSelectByAddressCommand
            {
                Address = "1 MONTGOMERY ST"
            };

            //act
            mediatorMock.Setup(x => x.Send(command, CancellationToken.None)).ReturnsAsync(facilitiesResult);

            var controller = new FacilitiesController(mediatorMock.Object);
            var result = await controller.GetFacilitiesByAdress(command);

            //assert
            mediatorMock.VerifyAll();
            Assert.NotNull(result);
        }
    }
}
