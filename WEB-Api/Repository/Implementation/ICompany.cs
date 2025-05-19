using CRUD.DBConnect;
using CRUD.Models;
using CRUD.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repository.Implementation
{
    public class ICompany : CompanyRepository
    {
        private readonly ApplicationDbContect _context;
        public ICompany(ApplicationDbContect context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetAllCompanyrep()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company?> GetCompanyByIdrep(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<Company> AddCompanyrep(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateCompanyrep(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task<bool> DeleteCompanyrep(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null) return false;
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
