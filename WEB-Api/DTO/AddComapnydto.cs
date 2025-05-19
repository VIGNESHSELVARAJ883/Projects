using System.ComponentModel.DataAnnotations;
using CRUD.Models;

namespace CRUD.DTO
{
    public class AddComapnydto
    {
        [Required]
        public string Name { get; set; }
    }
}
