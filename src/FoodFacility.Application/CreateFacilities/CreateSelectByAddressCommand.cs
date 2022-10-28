using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFacility.Application.CreateFacilities
{
    public class CreateSelectByAddressCommand : IRequest<List<CreateFacilitiesResult>>
    {
        /// <summary>
        /// Facility address
        /// </summary>
        public string Address { get; set; }
    }
}
