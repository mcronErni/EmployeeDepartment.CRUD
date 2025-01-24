using AutoMapper;
using EmployeeDepartmentCRUD.Domain.Contracts.Repositories;
using EmployeeDepartmentCRUD.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentCRUD.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("employees")]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeRepository.Get();
            return Ok(employees);
        }

        [HttpGet("employees/{id}")]
        public async Task<ActionResult<Employee>> GetById([FromRoute] int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost("employees")]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] Employee entity)
        {
            var createdEmployee = await _employeeRepository.AddEmployee(entity);
            if(createdEmployee is null)
            {
                return NotFound(new { Message = "Department Not Found."});
            }
            return CreatedAtAction(nameof(GetById), new { id = createdEmployee.EmployeeId }, createdEmployee);
        }

        [HttpPatch("employees/{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee([FromBody] Employee entity)
        {
            var updatedEmployee = await _employeeRepository.UpdateEmployee(entity);
            if(updatedEmployee is null)
            {
                return NotFound(new { Message = "No data to edit." });
            }
            return CreatedAtAction(nameof(GetById), new { id = updatedEmployee.EmployeeId }, updatedEmployee);
        }

        [HttpDelete("employees/{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee([FromRoute] int id){
            var employee = await _employeeRepository.DeleteEmployee(id);
            if(employee is null){
                return NotFound(new {Message = "User Doesn't Exist"});
            }
            return Ok();
        }
    }
}
