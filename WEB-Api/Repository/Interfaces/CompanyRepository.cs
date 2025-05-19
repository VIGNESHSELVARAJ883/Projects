using CRUD.Models;

namespace CRUD.Repository.Interfaces
{
    public interface CompanyRepository
    {
        Task<List<Company>> GetAllCompanyrep();
        Task<Company?> GetCompanyByIdrep(int id);
        Task<Company> AddCompanyrep(Company company);
        Task<Company> UpdateCompanyrep(Company company);
        Task<bool> DeleteCompanyrep(int id);
    }
}
