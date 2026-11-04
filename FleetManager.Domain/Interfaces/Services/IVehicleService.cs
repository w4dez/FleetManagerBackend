namespace FleetManager.Domain; 
/// <summary>
/// 
/// </summary>
public interface IVehicleService
{
    public List <VehicleDto> GetAll();
    public VehicleDto GetById(int id);
    public VehicleDto Create(CreateVehicleDto createVehicleDto);
    public bool Update(int id ,UpdateVehicleDto updateVehicleDto);
    public bool Delete(int id);

}