using CRUD.DTO;

namespace CRUD.Services.Interfaces
{
    public interface IDepartmentServices
    {
        Task<List<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto?> GetDepartmentById(int id);
        Task<DepartmentDto> AddDepartment(AddDepartmentdto dto);
        Task<DepartmentDto?> UpdateDepartment(int id, UpdateDepartmentdto dto);
        Task<bool> DeleteDepartment(int id);
    }
}
