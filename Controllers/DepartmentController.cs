using AutoMapper;
using EmployeeDepartmentCRUD.Domain.Contracts.Repositories;
using EmployeeDepartmentCRUD.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentCRUD.Controllers
{
    [ApiController]
    [Route("api/")]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("departments")]
        public async Task<IActionResult> Get()
        {
            var departments = await _departmentRepository.Get();
            return Ok(departments);
        }

        [HttpGet("departments/{id}")]
        public async Task<ActionResult<Department>> GetById([FromRoute] int id)
        {
            var department = await _departmentRepository.GetById(id);
            if (department is null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost("departments")]
        public async Task<ActionResult<Department>> AddDepartment([FromBody] Department entity)
        {
            var createdDepartment = await _departmentRepository.AddDepartment(entity);
            return CreatedAtAction(nameof(GetById), new { id = createdDepartment.DepartmentId }, createdDepartment);
        }
    }
}
