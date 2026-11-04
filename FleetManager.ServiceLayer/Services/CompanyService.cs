using FleetManager.Domain;
using FleetManager.Domian;


namespace FleetManager.ServiceLayer;

/// <summary>
/// 
/// </summary>
public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<CompanyDto> GetAll()
    {
        List<Company> companies = _companyRepository.GetAll();  
        return companies.Select(c => new CompanyDto
        {
            Id = c.Id,
            Name = c.Name,
            RegistrationCode = c.RegistrationCode,

             Vehicles = c.Vehicles.Select(v => new VehicleDto
        {
            Id = v.Id,
            LicensePlate = v.LicensePlate,
            Model = v.Model
            
        }).ToList()
        }).ToList();

        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public CompanyDto? GetById(int id)
    {
        Company? company = _companyRepository.GetById(id);
        if (company == null) return null;

        return new CompanyDto
        {
            Id = company.Id,
            Name = company.Name,
            RegistrationCode = company.RegistrationCode,
           
           
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="createDto"></param>
    /// <returns></returns>
    public CompanyDto Create(CreateCompanyDto createCompanyDto)
    {
        Company newCompany = new Company
        {
            Name = createCompanyDto.Name,
            RegistrationCode = createCompanyDto.RegistrationCode,
        };

        Company savedCompany = _companyRepository.Create(newCompany);

        return new CompanyDto
        {
            Id = savedCompany.Id,
            Name = savedCompany.Name,
            RegistrationCode = savedCompany.RegistrationCode
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateDto"></param>
    /// <returns></returns>
    public bool Update(int id, UpdateCompanyDto updateCompanyDto)
    {
        Company companyEntity = new Company
        {
            Id = id,
            Name = updateCompanyDto.Name,
            RegistrationCode = updateCompanyDto.RegistrationCode,
        };

        return _companyRepository.Update(id, companyEntity);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        return _companyRepository.Delete(id);
    }
}