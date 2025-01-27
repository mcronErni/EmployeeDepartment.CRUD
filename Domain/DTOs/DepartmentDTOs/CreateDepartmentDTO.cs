using EmployeeDepartmentCRUD.Domain.Models;

namespace EmployeeDepartmentCRUD.Domain.DTOs.Department
{
    public class CreateDepartmentDTO
    {
        public required string DepartmentName { get; set; }
        public string? Abbr { get; set; }
    }
}
