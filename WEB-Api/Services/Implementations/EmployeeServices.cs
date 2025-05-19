using CRUD.DTO;
using CRUD.Models;
using CRUD.Repository.Implementation;
using CRUD.Repository.Interfaces;
using CRUD.Services.Interfaces;

namespace CRUD.Services.Implementations
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployee _employeeRepository;

        public EmployeeServices(IEmployee employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employeedto> AddEmployee(AddEmployeeDto employee)
        {
            var added =await _employeeRepository.AddEmployeerep(new Employee
            {
                Name = employee.Name,
                Email = employee.Email,
                salary = employee.salary,
                DepartmentId = employee.DepartmentId,
                IsDeleted = false
            });
            return new Employeedto
            {
                Id = added.Id,
                Name = added.Name,
                Email = added.Email,
                Salary = added.salary,
                DepartmentName = added.Department.Name,
                CompanyName = added.Department.Company.Name
            };
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeByIdrep(id);
            if (employee == null)
            {
                throw new Exception("Employee Not Found");
            }
            return await _employeeRepository.DeleteEmployeerep(id);
        }

        public async Task<List<Employeedto>> FilterDetails(string? keyword, string? orderByField, string? orderBy, int? noOfRecords)
        {
            var employees =await _employeeRepository.FilterDetailsrep(keyword,orderByField,orderBy,noOfRecords);

            return employees.Select(d => new Employeedto
            {
                Id = d.Id,
                Name = d.Name,
                Email= d.Email,
                Salary = d.salary,
                DepartmentName = d.Department.Name,
                CompanyName = d.Department.Company.Name
            }).ToList(); 
        }

        public async Task<List<Employeedto>> GetAllEmployees()
        {
            var departments = await _employeeRepository.GetAllEmployeesrep();

            return departments.Select(d => new Employeedto
            {
                Id = d.Id,
                Name = d.Name,
                Email = d.Email,
                Salary = d.salary,
                DepartmentName = d.Department.Name,
                CompanyName = d.Department.Company.Name
            }).ToList();
        }

        public async Task<Employeedto> GetEmployeeById(int id)
        {
            var employee =  await _employeeRepository.GetEmployeeByIdrep(id);
            if (employee == null)
            {
                throw new Exception(message: "Employee Not Found");
            }
                return new Employeedto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.salary,
                    DepartmentName = employee.Department.Name,
                    CompanyName = employee.Department.Company.Name
                };
            
           
        }

        public async Task<Employeedto> UpdateEmployee(int id,UpdateEmployeeDto employee)
        {
            var empl = await _employeeRepository.GetEmployeeByIdrep(id);
            if (empl == null)
            {
                throw new Exception("Employee not found.");
            }

            empl.Name = employee.Name;
            empl.Email = employee.Email;
            empl.salary = employee.salary;
            await _employeeRepository.UpdateEmployeerep(empl);

            return new Employeedto
            {
                Id = id,
                Name = empl.Name,
                Email = empl.Email,
                Salary = empl.salary,
                DepartmentName = empl.Department.Name,
                CompanyName = empl.Department.Company.Name
            };
        }
    }
}
