using System.ComponentModel.DataAnnotations;

namespace CRUD.DTO
{
    public class UpdateDepartmentdto
    {
        [Required]
        public string Name { get; set; }
    }
}
