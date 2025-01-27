using AutoMapper;
using EmployeeDepartmentCRUD.Domain.Contracts.Repositories;
using EmployeeDepartmentCRUD.Domain.DTOs.Department;
using EmployeeDepartmentCRUD.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentCRUD.Controllers
{
    [ApiController]
    [Route("api/")]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet("departments")]
        public async Task<IActionResult> Get()
        {
            var departments = await _departmentRepository.Get();
            return Ok(_mapper.Map<IEnumerable<ReadDepartmentDTO>>(departments));
        }

        [HttpGet("departments/{id}")]
        public async Task<ActionResult<ReadDepartmentDTO>> GetById([FromRoute] int id)
        {
            var department = await _departmentRepository.GetById(id);
            if (department is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReadDepartmentDTO>(department));
        }

        [HttpPost("departments")]
        public async Task<ActionResult<Department>> AddDepartment([FromBody] CreateDepartmentDTO entity)
        {
            var clientDepartment = _mapper.Map<Department>(entity);
            var createdDepartment = await _departmentRepository.AddDepartment(clientDepartment);
            return CreatedAtAction(nameof(GetById), new { id = createdDepartment.DepartmentId }, createdDepartment);
        }
        [HttpPatch("departments/{id}")]
        public async Task<ActionResult<Department>> UpdateDepartment([FromRoute] int Id,[FromBody] UpdateDepartmentDTO entity)
        {
            //var clientDepartment = _mapper.Map<Department>(entity);
            var updatedDepartment = await _departmentRepository.UpdateDepartment(Id, entity);
            if(updatedDepartment is null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetById), new {id =  updatedDepartment.DepartmentId}, updatedDepartment);
        }
        [HttpDelete("departments/{id}")]
        public async Task<ActionResult<ReadDepartmentDTO>> DeleteDepartment(int id)
        {
            var department = await _departmentRepository.DeleteDepartment(id);
            if(department is null)
            {
                return NotFound(new {Message = "Department doesn't exist"});
            }
            return _mapper.Map<ReadDepartmentDTO>(department);
        }
    }
}
