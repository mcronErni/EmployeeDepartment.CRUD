namespace EmployeeDepartmentCRUD.Domain.DTOs.EmployeeDTOs
{
    public class CRUEmployeeDTO
    {
        public required string Name { get; set; }
        public DateOnly? Birthdate { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
    }
}
