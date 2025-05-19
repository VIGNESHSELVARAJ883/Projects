using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string Name { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
