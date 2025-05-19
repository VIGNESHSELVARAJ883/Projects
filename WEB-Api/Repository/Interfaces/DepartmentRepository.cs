using CRUD.Models;

namespace CRUD.Repository.Interfaces
{
    public interface DepartmentRepository
    {
        Task<List<Department>> GetAllDepartmentrep();
        Task<Department?> GetDepartmentByIdrep(int id);
        Task<Department> AddDepartmentrep(Department department);
        Task<Department> UpdateDepartmentrep(Department department);
        Task<bool> DeleteDepartmentrep(int id);
    }
}
