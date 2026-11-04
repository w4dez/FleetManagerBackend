namespace FleetManager.Domain;
/// <summary>
/// 
/// </summary>
public class CreateVehicleDto
{
    public string LicensePlate {get;set;} = string.Empty;
    public string Model {get;set;} = string.Empty;
    public int CompanyId {get;set;}
}
