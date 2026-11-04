namespace FleetManagerApi;
using FleetManager.Domain;
using FleetManager.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FleetManager.Domian;

[ApiController]
[Route("api/[controller]")]
[Authorize]
/// <summary>
/// 
/// </summary>
public class CompanyController : ControllerBase
{
    private readonly CompanyService _companyService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="companyService"></param>
    public CompanyController(CompanyService companyServiceService )
    {
        _companyService = companyServiceService;
    }
    [HttpGet]
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ActionResult<List<CompanyDto>> GetAll() 
    {
        var companies = _companyService.GetAll(); 
        return Ok(companies);
    }

    [HttpGet("by-id/{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ActionResult<CompanyDto> GetById(int id)
    {
        var companie = _companyService.GetById(id);
        return Ok(companie);
    }

    [HttpPost]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="createCompanyDto"></param>
    /// <returns></returns>
    public ActionResult<Company> Create([FromBody] CreateCompanyDto createCompanyDto)
    {
        var newCompany = _companyService.Create(createCompanyDto);
        return Created($"/api/company/by-id/{newCompany.Id}", newCompany);
    }

    [HttpPut("{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateCompanyDto"></param>
    /// <returns></returns>
    public IActionResult Update(int id, [FromBody] UpdateCompanyDto updateCompanyDto)
    {
        var success = _companyService.Update(id, updateCompanyDto);
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
        var success = _companyService.Delete(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
