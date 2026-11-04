namespace FleetManager.DataAccresssLayer;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// 
/// </summary>
public class VehiclesContext : DbContext
{   
    public VehiclesContext(DbContextOptions<VehiclesContext> options) : base(options)
    {
    }

    public DbSet<FleetManager.Domain.Vehicle> Vehicle { get; set; } = null!;
}
