namespace FleetManager.Domain;
/// <summary>
/// 
/// </summary>
public class Company
{
    public int Id {get;set;}
    public string Name {get;set;} = string.Empty; 
    public string RegistrationCode {get;set;} = string.Empty;

    public ICollection<Vehicle> Vehicles {get;set;} = new List <Vehicle>();
}