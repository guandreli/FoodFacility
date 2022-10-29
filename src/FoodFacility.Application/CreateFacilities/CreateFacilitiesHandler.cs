namespace FoodFacility.Application.CreateFacilities
{
    public class CreateFacilitiesHandler : IRequestHandler<CreateFacilitiesCommand, List<CreateFacilitiesResult>>
    {
        private readonly ILogger<CreateFacilitiesHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IFacilitiesService _facilitiesService;


        public CreateFacilitiesHandler(ILogger<CreateFacilitiesHandler> logger,
                                        IMapper mapper,
                                        IFacilitiesService facilitiesService)
        {
            _logger = logger;
            _mapper = mapper;
            _facilitiesService = facilitiesService;
        }

        public async Task<List<CreateFacilitiesResult>> Handle(CreateFacilitiesCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogDebug("Init Handle");
                if (!IsCommandValid(request))
                    throw new HttpResponseException(HttpStatusCode.BadRequest, "Informed data is not valid.");
                var response = new List<FacilitiesResponse>();
                if (!string.IsNullOrWhiteSpace(request.FacilityName))
                    response = await _facilitiesService.GetFacilitiesByNameAsync(request.FacilityName, request.Status);
                else if (!string.IsNullOrWhiteSpace(request.Address))
                    response = await _facilitiesService.GetFacilitiesByAddressAsync(request.Address);


                return _mapper.Map<List<CreateFacilitiesResult>>(response);
            }
            catch
            {
                throw;
            }
        }

        private bool IsCommandValid(CreateFacilitiesCommand request)
        {
            var valid = false;
            
            if (!string.IsNullOrWhiteSpace(request.FacilityName))
                valid = true;
            else if (!string.IsNullOrWhiteSpace(request.Address))
                valid = true;
            else if (request.Latitude.HasValue && request.Longitude.HasValue)
                valid = true;

            return valid;
        }
    }
}
