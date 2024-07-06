using ExamApp.Abstraction;
using ExamApp.Concrete;

namespace ExamApp.Extensions;

public static class ServiceManagementExtension
{
    public static void AddServiceManagementExtension(this IServiceCollection services)
    {
        services.AddScoped<IDersService, DersService>();
        services.AddScoped<IImtahanService, ImtahanService>();
        services.AddScoped<IShagirdService, ShagirdService>();
    }
}
