using FleetManager.Domian;

namespace FleetManager.Domain;
/// <summary>
/// 
/// </summary>
public interface ICompanyService
{
    public List <CompanyDto> GetAll();
    public CompanyDto? GetById(int id);
    public CompanyDto Create(CreateCompanyDto createCompanyDto);
    public bool Update(int id ,UpdateCompanyDto updateCompanyDto);
    public bool Delete(int id);}