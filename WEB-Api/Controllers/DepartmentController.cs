using CRUD.DTO;
using CRUD.Models;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentServices _repos;

        public DepartmentController(IDepartmentServices repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            var departments = await _repos.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var dept = await _repos.GetDepartmentById(id);
            if (dept == null)
            {
                return NotFound();
            }

            return Ok(dept);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(AddDepartmentdto deptment)
        {
            var dept = await _repos.AddDepartment(deptment);
            return Ok(dept);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentdto dept)
        {
            if (dept.Name == null)
            {
                return BadRequest("Name cannot be empty");
            }

            var updated = await _repos.UpdateDepartment(id, dept);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repos.DeleteDepartment(id);
            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
