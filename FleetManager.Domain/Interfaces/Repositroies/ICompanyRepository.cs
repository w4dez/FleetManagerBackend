namespace FleetManager.Domain; 

/// <summary>
/// 
/// </summary>
public interface ICompanyRepository
{
    public List <Company> GetAll();
    public Company GetById(int id);
    public Company Create(Company Company);
    public bool Update(int id ,Company Company);
    public bool Delete(int id);

}