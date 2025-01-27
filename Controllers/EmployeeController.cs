using AutoMapper;
using EmployeeDepartmentCRUD.Domain.Contracts.Repositories;
using EmployeeDepartmentCRUD.Domain.DTOs.EmployeeDTOs;
using EmployeeDepartmentCRUD.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentCRUD.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet("employees")]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeRepository.Get();
            if (employees == null) { 
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CRUEmployeeDTO>>(employees));
        }

        [HttpGet("employees/{id}")]
        public async Task<ActionResult<CRUEmployeeDTO>> GetById([FromRoute] int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CRUEmployeeDTO>(employee));
        }

        [HttpPost("employees")]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] CRUEmployeeDTO entity)
        {
            var clientEmployee = _mapper.Map<Employee>(entity);
            var createdEmployee = await _employeeRepository.AddEmployee(clientEmployee);
            if(createdEmployee is null)
            {
                return NotFound(new { Message = "Department Not Found."});
            }
            return CreatedAtAction(nameof(GetById), new { id = createdEmployee.EmployeeId }, createdEmployee);
        }

        [HttpPatch("employees/{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee([FromRoute] int Id, [FromBody] CRUEmployeeDTO entity)
        {
            var updatedEmployee = await _employeeRepository.UpdateEmployee(Id, entity);
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
