using CRUD.Models;

namespace CRUD.Repository.Interfaces
{
    public interface EmployeeRepository
    {
        Task<List<Employee>> GetAllEmployeesrep();
        Task<Employee?> GetEmployeeByIdrep(int id);
        Task<Employee> AddEmployeerep(Employee employee);
        Task<Employee> UpdateEmployeerep(Employee employee);
        Task<bool> DeleteEmployeerep(int id);
        Task<List<Employee>> FilterDetailsrep(string? keyword, string? orderByField, string? orderBy, int? noOfRecords);
    }
}
