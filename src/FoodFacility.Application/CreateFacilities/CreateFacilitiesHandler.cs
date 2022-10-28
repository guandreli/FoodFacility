using FoodFacility.Domain.Interfaces.Services;

namespace FoodFacility.Application.CreateFacilities
{
    public class CreateFacilitiesHandler : IRequestHandler<CreateSelectByNameCommand, List<CreateFacilitiesResult>>,
                                           IRequestHandler<CreateSelectByAddressCommand, List<CreateFacilitiesResult>>
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

        public async Task<List<CreateFacilitiesResult>> Handle(CreateSelectByNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogDebug("Init Handle");
                var response = await _facilitiesService.GetFacilitiesByNameAsync(request.FacilityName, request.Status);
                return _mapper.Map<List<CreateFacilitiesResult>>(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<CreateFacilitiesResult>> Handle(CreateSelectByAddressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogDebug("Init Handle");
                var response = await _facilitiesService.GetFacilitiesByAddressAsync(request.Address);
                return _mapper.Map<List<CreateFacilitiesResult>>(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
