using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DBConnect
{
    public class ApplicationDbContect : DbContext
    {
        public ApplicationDbContect(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
