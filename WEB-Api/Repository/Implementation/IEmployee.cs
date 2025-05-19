using CRUD.DBConnect;
using CRUD.DTO;
using CRUD.Models;
using CRUD.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repository.Implementation
{
    public class IEmployee : EmployeeRepository
    {
        private readonly ApplicationDbContect _context;
        public IEmployee(ApplicationDbContect context) => _context = context;

        public async Task<List<Employee>> GetAllEmployeesrep()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .ThenInclude(d => d.Company)
                .Where(e => !e.IsDeleted)
                .ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdrep(int id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .ThenInclude(d => d.Company)
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        public async Task<Employee> AddEmployeerep(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            await _context.Employees
                .Include(e => e.Department)
                .ThenInclude(d => d.Company).LoadAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployeerep(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            await _context.Entry(employee).Reference(e => e.Department).LoadAsync();
            if (employee.Department != null)
            {
                await _context.Entry(employee.Department).Reference(d => d.Company).LoadAsync();
            }

            return employee;
        }

        public async Task<bool> DeleteEmployeerep(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null || employee.IsDeleted) return false;
            employee.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Employee>> FilterDetailsrep(string? keyword, string? orderByField, string? orderBy, int? noOfRecords)
        {
            var query = _context.Employees
                .Include(e => e.Department)
                .ThenInclude(d => d.Company)
                .Where(e => !e.IsDeleted)
                .AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(e =>
                    e.Name.ToLower().Contains(keyword) ||
                    e.Email.ToLower().Contains(keyword) ||
                    e.salary.ToString().Contains(keyword) ||
                    e.Department.Name.ToLower().Contains(keyword) ||
                    e.Department.Company.Name.ToLower().Contains(keyword));
            }

            bool isAsc = orderBy?.ToLower() == "asc";
            switch (orderByField?.ToLower())
            {
                case "name":
                    query = isAsc ? query.OrderBy(e => e.Name) : query.OrderByDescending(e => e.Name);
                    break;
                case "salary":
                    query = isAsc ? query.OrderBy(e => e.salary) : query.OrderByDescending(e => e.salary);
                    break;
                default:
                    query = isAsc ? query.OrderBy(e => e.Id) : query.OrderByDescending(e => e.Id);
                    break;
            }

            if (noOfRecords.HasValue)
                query = query.Take(noOfRecords.Value);
            await _context.Employees
                .Include(e => e.Department)
                .ThenInclude(d => d.Company).LoadAsync();
            return await query.ToListAsync();
        }
    }
}
