using FleetManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.DataAccresssLayer;
/// <summary>
/// 
/// </summary>
public class VehicleRepository : IVehicleRepository
{
    private readonly VehiclesContext _context;

    public VehicleRepository(VehiclesContext context)
    {
        _context = context;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Vehicle> GetAll()
    {
        List<Vehicle> vehicles = _context.Vehicle
        .Include(v => v.Company)
        .ToList();

        return vehicles;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Vehicle? GetById(int id)
    {
        Vehicle? vehicle = _context.Vehicle
        .Include(v => v.Company)
        .FirstOrDefault(v => v.Id == id);

        return vehicle;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="licensePlate"></param>
    /// <returns></returns>
    public Vehicle? GetByLicensePlate(string licensePlate)
    {
        Vehicle? vehicle = _context.Vehicle
        .Include(v => v.Company)
        .FirstOrDefault(v => v.LicensePlate == licensePlate);

        return vehicle;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vehicle"></param>
    /// <returns></returns>
    public Vehicle Create(Vehicle vehicle)
    {
        _context.Vehicle.Add(vehicle);
        _context.SaveChanges();
        
        return vehicle;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="vehicle"></param>
    /// <returns></returns>
    public bool Update(int id, Vehicle vehicle)
    {
        Vehicle? vehicleToUpdate = _context.Vehicle.FirstOrDefault(v => v.Id == id);

        if(vehicleToUpdate == null) return false;

        vehicleToUpdate.LicensePlate = vehicle.LicensePlate;
        vehicleToUpdate.Model = vehicle.Model;
        vehicleToUpdate.CompanyId = vehicle.CompanyId;

        _context.SaveChanges();
        return true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        Vehicle? vehicleToDelete = _context.Vehicle.FirstOrDefault(v => v.Id == id);

        if (vehicleToDelete == null) return false;

        _context.Vehicle.Remove(vehicleToDelete);
        _context.SaveChanges();

        return true;
    }
}