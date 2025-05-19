using CRUD.DTO;
using CRUD.Models;
using CRUD.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyServices _repos;

        public CompanyController(ICompanyServices repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompany()
        {
            var companies = await _repos.GetAllCompany();
            return Ok(companies);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetComapnyById(int id)
        {
            var company = await _repos.GetCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> AddComapny(AddComapnydto addcompany)
        {
            if (string.IsNullOrWhiteSpace(addcompany.Name))
            {
                return BadRequest("Name cannot be empty.");
            }

            var companie = new Company
            {
                Name = addcompany.Name
            };

            var created = await _repos.AddCompany(companie);

            var result = new CompanyDto
            {
                Id = created.Id,
                Name = created.Name
            };

            return CreatedAtAction(nameof(GetComapnyById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateComapnydto company)
        {
            

            var updated = await _repos.UpdateCompany(id,company);

            var result = new CompanyDto
            {
                Id = updated.Id,
                Name = updated.Name
            };

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repos.DeleteCompany(id);
            if (!success)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
