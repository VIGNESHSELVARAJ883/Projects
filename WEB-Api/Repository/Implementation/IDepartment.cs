using CRUD.DBConnect;
using CRUD.Models;
using CRUD.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CRUD.Repository.Implementation
{
    public class IDepartment : DepartmentRepository
    {
        private readonly ApplicationDbContect _context;
        public IDepartment(ApplicationDbContect context) => _context = context;

        public async Task<List<Department>> GetAllDepartmentrep()
        {
            return await _context.Departments
                .Include(d => d.Company)
                .Include(d => d.Employees)
                .ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdrep(int id)
        {
            return await _context.Departments
                .Include(d => d.Company)
                .Include(d => d.Employees)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Department> AddDepartmentrep(Department department)
        {

            _context.Add(department);
            await _context.SaveChangesAsync();
            await _context.Entry(department).Reference(d => d.Company).LoadAsync();
            return department;
        }

        public async Task<Department> UpdateDepartmentrep(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            await _context.Entry(department).Reference(d => d.Company).LoadAsync();
            return department;
        }

        public async Task<bool> DeleteDepartmentrep(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return false;
            }
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
