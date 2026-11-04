namespace FleetManager.Domain; 
/// <summary>
/// 
/// </summary>
public class Vehicle
{   
    public int Id {get;set;}
    public string LicensePlate {get;set;} = string.Empty;
    public string Model {get;set;} = string.Empty;
    public int CompanyId {get;set;}
    public Company? Company {get;set;}
}