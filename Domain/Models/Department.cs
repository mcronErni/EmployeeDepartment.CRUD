namespace EmployeeDepartmentCRUD.Domain.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public required string DepartmentName { get; set; }
        public string? Abbr { get; set; }

        public ICollection<Employee?>? Employees { get; set; }
    }
}
