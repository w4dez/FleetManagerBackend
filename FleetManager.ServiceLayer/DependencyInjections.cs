using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FleetManager.DataAccresssLayer;
using FleetManager.ServiceLayer;
using FleetManager.Domain;

namespace FleetManager.ServiceLayer; 

public static class DependencyInjection
{   
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddServiceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccessLayer(configuration); 
        services.AddScoped<AuthService>();
        services.AddScoped<CompanyService>();
        services.AddScoped<VehicleService>();
        return services;
    }
}