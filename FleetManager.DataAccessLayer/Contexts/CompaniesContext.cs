namespace FleetManager.DataAccresssLayer;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// 
/// </summary>
public class CompaniesContext : DbContext
{   
    public CompaniesContext(DbContextOptions<CompaniesContext> options) : base(options)
    {
    }

    public DbSet<FleetManager.Domain.Company> Company { get; set; } = null!;
}
