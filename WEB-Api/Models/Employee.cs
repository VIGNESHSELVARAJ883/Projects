using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public  int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]  
        public decimal salary {  get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public bool IsDeleted { get; set; } = false;                                                                                                                                                                                                                        
        public  Department? Department { get; set; }
    }                                                                                                                                                                                                               
}
                                                                                                                                                                                                                                                                                                