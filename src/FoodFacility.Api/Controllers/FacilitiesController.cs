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

        [HttpGet("SearchByName")]
        [ProducesResponseType(typeof(List<CreateFacilitiesResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetFacilitiesByName([FromQuery] CreateSelectByNameCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("SearchByAdress")]
        [ProducesResponseType(typeof(List<CreateFacilitiesResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(StackSpot.ErrorHandler.HttpResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetFacilitiesByAdress([FromQuery] CreateSelectByAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
