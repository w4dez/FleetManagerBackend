using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace FleetManager.DataAccresssLayer;
using FleetManager.Domain;

/// <summary>
/// 
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds all services (repositories) of the data access layer.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>, to which the services are added to.</param>
    /// <param name="configuration">The collection for chaining more Calls.</param>
    /// <returns></returns>
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<VehiclesContext>(options =>
        {
            options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString));
        });
        services.AddDbContext<CompaniesContext>(options =>
        {
            options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString));
        });


        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();

        return services;
    }
}