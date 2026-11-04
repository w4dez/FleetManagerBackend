namespace FleetManager.Domain;
using System.ComponentModel.DataAnnotations; 
/// <summary>
/// 
/// </summary>
public class CreateCompanyDto
{   
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(60, ErrorMessage = "Name cannot exceed 60 characters.")]
    public string Name {get;set;} = string.Empty;
    [Required(ErrorMessage = "Name is required.")]
    [MaxLength(20, ErrorMessage = "Name cannot exceed 20 characters.")]    
    public string RegistrationCode {get;set;} = string.Empty;

}