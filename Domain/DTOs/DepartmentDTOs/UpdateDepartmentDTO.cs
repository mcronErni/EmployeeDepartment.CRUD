namespace EmployeeDepartmentCRUD.Domain.DTOs.Department
{
    public class UpdateDepartmentDTO
    {
        public required string DepartmentName { get; set; }
        public string? Abbr { get; set; }
    }
}
