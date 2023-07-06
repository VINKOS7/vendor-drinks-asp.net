using KSK.Vendor.Drinks.Domain.Domain.Aggregates.Drink;
using KSK.Vendor.Drinks.Infrastructure.Repo;

namespace KSK.Vendor.Drinks.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IDrinkRepo, DrinkRepo>();

        return services;
    }
}

