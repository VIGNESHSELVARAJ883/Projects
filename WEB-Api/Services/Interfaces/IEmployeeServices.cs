using CRUD.DTO;
using CRUD.Models;

namespace CRUD.Services.Interfaces
{
    public interface IEmployeeServices
    {
        Task<List<Employeedto>> GetAllEmployees();
        Task<Employeedto?> GetEmployeeById(int id);
        Task<Employeedto> AddEmployee(AddEmployeeDto employee);
        Task<Employeedto> UpdateEmployee(int id,UpdateEmployeeDto employee);
        Task<bool> DeleteEmployee(int id);
        Task<List<Employeedto>> FilterDetails(string? keyword, string? orderByField, string? orderBy, int? noOfRecords);
    }
}
