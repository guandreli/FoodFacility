using FoodFacility.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFacility.Application.CreateFacilities
{
    public class CreateFacilitiesHandler : IRequestHandler<CreateSelectByNameCommand, List<CreateSelectByNameResult>>
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

        public async Task<List<CreateSelectByNameResult>> Handle(CreateSelectByNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogDebug("Init Handle");
                var response = await _facilitiesService.GetFacilitiesByNameAsync(request.FacilityName, request.Status);
                return _mapper.Map<List<CreateSelectByNameResult>>(response);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
