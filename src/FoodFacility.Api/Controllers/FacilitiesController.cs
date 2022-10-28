using FoodFacility.Application.CreateFacilities;

namespace FoodFacility.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacilitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FacilitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<CreateSelectByNameResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CreateSelectByNameCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
