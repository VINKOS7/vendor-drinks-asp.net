using KSK.Vendor.Drinks.Infrastructure;
using KSK.Vendor.Drinks.Infrastructure.Services;

namespace KSK.Vendor.Drinks.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUploadService, UploadService>();

        return services;
    }
}
