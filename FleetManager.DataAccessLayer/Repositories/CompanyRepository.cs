using FleetManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace FleetManager.DataAccresssLayer;

/// <summary>
/// 
/// </summary> <summary>
/// 
/// </summary>
public class CompanyRepository : ICompanyRepository
{
    private readonly CompaniesContext _context;

    public CompanyRepository(CompaniesContext context)
    {
        _context = context;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Company> GetAll()
    {
        return _context.Company.Include(c =>c.Vehicles).ToList();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Company? GetById(int id)
    {
        Company? company = _context.Company
        .Include(c => c.Vehicles)
        .FirstOrDefault(c => c.Id == id);

        return company;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="company"></param>
    /// <returns></returns>
    public Company Create(Company company)
    {
        _context.Company.Add(company);
        _context.SaveChanges();
        
        return company;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="company"></param>
    /// <returns></returns>
    public bool Update(int id, Company company)
    {
        Company? companyToUpdate = _context.Company.FirstOrDefault(c => c.Id == id);

        if(companyToUpdate== null) return false;

        companyToUpdate.Name = company.Name;
        companyToUpdate.RegistrationCode = company.RegistrationCode;

        _context.SaveChanges();
        return true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool Delete(int id)
    {
        Company? companyToDelete = _context.Company.FirstOrDefault(c => c.Id == id);

        if (companyToDelete == null) return false;

        _context.Company.Remove(companyToDelete);
        _context.SaveChanges();

        return true;
    }
}