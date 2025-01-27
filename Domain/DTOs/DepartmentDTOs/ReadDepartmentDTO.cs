using EmployeeDepartmentCRUD.Domain.Models;

namespace EmployeeDepartmentCRUD.Domain.DTOs.Department
{
    public class ReadDepartmentDTO
    {
        public required string DepNameAbbr { get; set; }

        public ICollection<Employee?>? Employees { get; set; }
    }
}
