using System.ComponentModel.DataAnnotations;

namespace CRUD.DTO
{
    public class Employeedto
    {

            public int Id { get; set; }
            public string Name { get; set; } = null!;
            public string Email { get; set; } = null!;
            public decimal Salary { get; set; }
            public string DepartmentName { get; set; } = null!;
            public string CompanyName { get; set; } = null!;
        }
    }

