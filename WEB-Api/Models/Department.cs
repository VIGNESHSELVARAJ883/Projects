using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CRUD.Models
{
    public class Department
    {
            [Key]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            public int CompanyId { get; set; }
            public Company? Company { get; set; }
            public  ICollection<Employee> Employees { get; set; }
    }
}
