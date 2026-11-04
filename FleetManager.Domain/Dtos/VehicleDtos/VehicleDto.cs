namespace FleetManager.Domain;
/// <summary>
/// 
/// </summary>
public class VehicleDto
{
    public int Id {get;set;}
    public string LicensePlate {get;set;} = string.Empty;
    public string Model {get;set;} = string.Empty;
    public int CompanyId {get;set;}
    public string CompanyName {get;set;} = string.Empty;
}
