namespace FleetManager.Domain; 
/// <summary>
/// 
/// </summary>
public class CompanyDto
{
    public int Id {get;set;}
    public string Name {get;set;} = string.Empty; 
    public string RegistrationCode {get;set;} = string.Empty;
    public List<VehicleDto> Vehicles { get; set; } = new List<VehicleDto>();


}