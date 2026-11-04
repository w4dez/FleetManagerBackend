namespace FleetManager.Domain;

/// <summary>
/// 
/// </summary>
public interface IVehicleRepository
{
    public List<Vehicle> GetAll();
    public Vehicle? GetById(int id);
    public Vehicle GetByLicensePlate (string LicensePlate);
    public Vehicle Create( Vehicle vehicle);
    public bool Update(int id ,Vehicle vehicle);
    public bool Delete(int id);
}