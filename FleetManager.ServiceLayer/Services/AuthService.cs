namespace FleetManager.ServiceLayer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using FleetManager.Domain;

/// <summary>
/// 
/// </summary>
public class AuthService
{       private readonly IConfiguration _configuration;

    private readonly IVehicleRepository _vehicleRepository;
/// <summary>
/// 
/// </summary>
/// <param name="vehicleRepository"></param>
/// <param name="configuration"></param>
public AuthService(IVehicleRepository vehicleRepository, IConfiguration configuration)
{
    _vehicleRepository = vehicleRepository;
    _configuration = configuration;
}

private string GenerateJwtToken(Vehicle vehicle)
{
    JwtSecurityTokenHandler tokenHandler = new 
        JwtSecurityTokenHandler();

    byte[] key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

    Claim[] claims = new[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, 
            vehicle.Id.ToString()),
        new Claim("LicensePlate", vehicle.LicensePlate)
            };

    SecurityTokenDescriptor tokenDescriptor = new 
        SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.UtcNow.AddHours(2),
        Issuer = _configuration["Jwt:Issuer"],
        Audience = _configuration["Jwt:Audience"],
        SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
        )
    };

    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
}

    public FleetManager.Domain.LoginResponseDto? Login(LoginRequestDto loginRequest)
{ 
    // 1. Find user in the database
    // NOTE: In a real application, a password comparison would also 
     //  take place here!
    Vehicle? vehicle = _vehicleRepository.GetByLicensePlate(loginRequest.LicensePlate);

    if (vehicle == null)
        return null; // User not found

    // 2. Generate token
    string token = GenerateJwtToken(vehicle);
    return new LoginResponseDto { Token = token };
}

}
