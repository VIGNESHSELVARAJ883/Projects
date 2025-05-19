using CRUD.DTO;
using CRUD.Models;
using CRUD.Repository.Implementation;
using CRUD.Repository.Interfaces;
using CRUD.Services.Interfaces;

namespace CRUD.Services.Implementations
{
    public class ComapnyServices : ICompanyServices
    {
        private readonly ICompany _context;

        public ComapnyServices(ICompany companyRepository)
        {
            _context = companyRepository;
        }

        // Get all companies
        public async Task<List<CompanyDto>> GetAllCompany()
        {
            var companies = await _context.GetAllCompanyrep();
            var companyDtos = companies.Select(c => new CompanyDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return companyDtos;
        }

        // Get company by ID
        public async Task<CompanyDto> GetCompanyById(int id)
        {
            var company = await _context.GetCompanyByIdrep(id);
            if (company == null)
                return null;

            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name
            };
        }

        // Add new company
        public async Task<Company> AddCompany(Company company)
        {
            return await _context.AddCompanyrep(company);
        }

        // Update existing company
        public async Task<Company> UpdateCompany(int id, UpdateComapnydto company)
        {
            var existing = await _context.GetCompanyByIdrep(id);


            if (string.IsNullOrWhiteSpace(company.Name))
            {
                throw new Exception("Company name must not be null or empty.");
            }

            if (existing == null)
            {
                throw new Exception("Company not found.");
            }

            existing.Name = company.Name;

            return await _context.UpdateCompanyrep(existing);
        }

        // Delete company by ID
        public async Task<bool> DeleteCompany(int id)
        {
            return await _context.DeleteCompanyrep(id);
        }
    }
}
