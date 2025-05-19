using CRUD.DTO;
using CRUD.Models;
using CRUD.Repository.Implementation;
using CRUD.Repository.Interfaces;
using CRUD.Services.Interfaces;

namespace CRUD.Services.Implementations
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartment _departmentRepository;

        public DepartmentServices(IDepartment departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<DepartmentDto> AddDepartment(AddDepartmentdto dto)
        {
            var department =await _departmentRepository.AddDepartmentrep( new Department
            {
                Name = dto.Name,
                CompanyId = dto.CompanyId
            });
           
            return  new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                CompanyName = department.Company.Name
            }; ;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            return await _departmentRepository.DeleteDepartmentrep(id);
        }

        public async Task<List<DepartmentDto>> GetAllDepartments()
        {
            var departments = await _departmentRepository.GetAllDepartmentrep();

            return departments.Select(d => new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                CompanyName = d.Company.Name
            }).ToList();

        }

        public async Task<DepartmentDto?> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetDepartmentByIdrep(id);
            if (department == null) return null;

            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                CompanyName = department.Company.Name
            };
        }

        public async Task<DepartmentDto> UpdateDepartment(int id, UpdateDepartmentdto dto)
        {
            var department = await _departmentRepository.GetDepartmentByIdrep(id);
            if (department == null)
            {
                throw new Exception("Department Not Found");
            }

            department.Name = dto.Name;
            await _departmentRepository.UpdateDepartmentrep(department);

            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                CompanyName = department.Company.Name
            };
        }
    }
}
