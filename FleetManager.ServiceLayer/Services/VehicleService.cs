namespace FleetManager.ServiceLayer;
using FleetManager.Domain;
/// <summary>
/// 
/// </summary>
public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository; 

    public VehicleService (IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<VehicleDto> GetAll()
    {
        List <Vehicle> vehicles = _vehicleRepository.GetAll();

        List<VehicleDto> dtos = vehicles.Select(vehicle => new VehicleDto
        {
            Id = vehicle.Id,
            LicensePlate = vehicle.LicensePlate,
            Model = vehicle.Model,
            CompanyId = vehicle.CompanyId,
            CompanyName = vehicle.Company != null ? vehicle.Company.Name : string.Empty
            
        }).ToList();

        return dtos;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public VehicleDto GetById(int id)
    {
        Vehicle? vehicle = _vehicleRepository.GetById(id);
        if (vehicle == null) return null;
        return new VehicleDto
        {
            Id = vehicle.Id,
            LicensePlate = vehicle.LicensePlate,
            Model = vehicle.Model,
            CompanyId = vehicle.CompanyId,
            CompanyName = vehicle.Company != null ? vehicle.Company.Name : string.Empty
            
        };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="licensePlate"></param>
    /// <returns></returns>
    public VehicleDto GetByLicensePlate(string licensePlate)
    {
        Vehicle? vehicle = _vehicleRepository.GetByLicensePlate(licensePlate);
        if (vehicle == null) return null;
        return new VehicleDto
        {
            Id = vehicle.Id,
            LicensePlate = vehicle.LicensePlate,
            Model = vehicle.Model,
            CompanyId = vehicle.CompanyId,
            CompanyName = vehicle.Company != null ? vehicle.Company.Name : string.Empty
            
        };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="createVehicleDto"></param>
    /// <returns></returns>
    public VehicleDto Create(CreateVehicleDto createVehicleDto)
    {
        Vehicle newVehicle = new Vehicle
        {
            LicensePlate = createVehicleDto.LicensePlate,
            Model = createVehicleDto.Model,
            CompanyId = createVehicleDto.CompanyId
        };

        Vehicle savedVehicle = _vehicleRepository.Create(newVehicle);

        return new VehicleDto
        {
            Id = savedVehicle.Id,
            LicensePlate = savedVehicle.LicensePlate,
            Model = savedVehicle.Model,
            CompanyId = savedVehicle.CompanyId
        };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateVehicleDto"></param>
    /// <returns></returns>
    public bool Update(int id,UpdateVehicleDto updateVehicleDto)
    {
        Vehicle vehicleEntity = new Vehicle
        {
            Id = id,
            LicensePlate = updateVehicleDto.LicensePlate,
            Model = updateVehicleDto.Model,
            CompanyId = updateVehicleDto.CompanyId
        };

        return _vehicleRepository.Update(id, vehicleEntity);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        return _vehicleRepository.Delete(id);
    }
}