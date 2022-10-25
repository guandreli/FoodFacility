using FoodFacility.Domain.Interfaces.Services;
using FoodFacility.Domain.Models;

namespace FoodFacility.Infrastructure.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        public async Task<HelloWorldResponse> Create(string userName, int userLevel)
        {
            await Task.Delay(2000);
            return new HelloWorldResponse
            {
                UserId = Guid.NewGuid(),
                Level = userLevel,
                UserName = userName
            };
        }
    }
}