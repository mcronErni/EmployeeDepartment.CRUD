using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentCRUD.Domain.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public required string Name { get; set; }
        public DateOnly? Birthdate { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
    }
}
