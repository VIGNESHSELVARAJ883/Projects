using CRUD.DTO;
using CRUD.Models;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _repos;

        public EmployeeController(IEmployeeServices repos)
        {
            _repos = repos;
        }

        [HttpGet("AllEmployees")]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var employees = await _repos.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var emp = await _repos.GetEmployeeById(id);
            if (emp is null)
            {
                return NotFound();
            }

            return Ok(emp);
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(AddEmployeeDto addemployee)
        {
            var added = _repos.AddEmployee(addemployee);

            return Ok(added.Result);
        }

        [HttpPut("UpdateEmployee/{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto updateemp)
        {
            try
            {
                var updated = await _repos.UpdateEmployee(id, updateemp);
                if (updated == null)
                {
                    return NotFound($"No employee found with ID {id}");
                }
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }


        [HttpDelete("DeleteEmployee/{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var result = _repos.DeleteEmployee(id);

            return Ok();
        }

        [HttpGet("filter")]
        public async Task<ActionResult> GetFilteredEmployees([FromQuery] EmployeeFilterDto filterDto)
        {
            var result = await _repos.FilterDetails(
                filterDto.Filter,
                filterDto.OrderByField,
                filterDto.OrderBy,
                filterDto.NoOfRecords);

            return Ok(result);
        }
    }
}
