using CRUD.DTO;
using CRUD.Models;

namespace CRUD.Services.Interfaces
{
    public interface ICompanyServices  
    {
        Task<List<CompanyDto>> GetAllCompany();
        Task<CompanyDto> GetCompanyById(int id);
        Task<Company> AddCompany(Company company);
        Task<Company> UpdateCompany(int id, UpdateComapnydto company);
        Task<bool> DeleteCompany(int id);
    }
}
