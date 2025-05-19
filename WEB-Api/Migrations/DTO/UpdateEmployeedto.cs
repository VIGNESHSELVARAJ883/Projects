using CRUD.Models;
using System.ComponentModel.DataAnnotations;

namespace CRUD.DTO
{
    public class UpdateEmployeeDto
    {
        [Required]
        public  string Name { get; set; }
        [Required]
        public  string Email { get; set; }
        [Required]
        public decimal salary { get; set; }

    }
}
