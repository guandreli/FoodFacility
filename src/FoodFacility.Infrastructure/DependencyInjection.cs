using FoodFacility.Domain.Interfaces.Services;
using FoodFacility.Infrastructure.HttpClients;
using FoodFacility.Infrastructure.Services;
using Refit;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FoodFacility.Infrastructure;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //Services
        services.AddScoped<IHelloWorldService, HelloWorldService>();
        services.AddScoped<IFacilitiesService, FacilitiesService>();

        SetupRefit(services, configuration);
        return services;
    }

    private static void SetupRefit(IServiceCollection services, IConfiguration configuration)
    {
        var dataSFBaseUrl = configuration.GetSection("DataSF")["BaseUrl"];

        services.AddRefitClient<IMobileFoodRefit>(GetNewtonsoftJsonRefitSettings())
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(dataSFBaseUrl));
    }

    public static RefitSettings GetNewtonsoftJsonRefitSettings() => new RefitSettings(new NewtonsoftJsonContentSerializer(new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));
}