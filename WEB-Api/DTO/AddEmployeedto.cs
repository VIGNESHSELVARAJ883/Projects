using CRUD.Models;
using System.ComponentModel.DataAnnotations;

namespace CRUD.DTO
{
    public class AddEmployeeDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }

        [Required]
        public decimal salary { get; set; }
        public int DepartmentId { get; set; }

    }
}
