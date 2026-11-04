namespace FleetManager.Domain;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// 
/// </summary>
public class LoginRequestDto
{
    [Required]
    [MaxLength(15)] // Optional: Most license plates are under 15 characters
    public string LicensePlate { get; set; } = string.Empty;
}