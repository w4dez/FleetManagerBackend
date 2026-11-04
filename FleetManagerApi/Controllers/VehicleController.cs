namespace FleetManagerApi;
using FleetManager.Domain;
using FleetManager.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
[Authorize]
/// <summary>
/// 
/// </summary>
public class VehicleController : ControllerBase
{
    private readonly VehicleService _vehicleService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vehicleService"></param>
    public VehicleController(VehicleService vehicleService )
    {
        _vehicleService = vehicleService;
    }
    [HttpGet]
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ActionResult<List<VehicleDto>> GetAll() 
    {
        var vehicles = _vehicleService.GetAll(); 
        return Ok(vehicles);
    }

    [HttpGet("by-id/{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ActionResult<VehicleDto> GetById(int id)
    {
        var vehicle = _vehicleService.GetById(id);
        return Ok(vehicle);
    }

    [HttpPost]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="createVehicleDto"></param>
    /// <returns></returns>
    public ActionResult<Vehicle> Create([FromBody] CreateVehicleDto createVehicleDto)
    {
        var newVehicle = _vehicleService.Create(createVehicleDto);
        return Created($"/api/vehicle/by-id/{newVehicle.Id}", newVehicle);
    }

    [HttpPut("{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateVehicleDto"></param>
    /// <returns></returns>
    public IActionResult Update(int id, [FromBody] UpdateVehicleDto updateVehicleDto)
    {
        var success = _vehicleService.Update(id, updateVehicleDto);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IActionResult Delete(int id)
    {
        var success = _vehicleService.Delete(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
