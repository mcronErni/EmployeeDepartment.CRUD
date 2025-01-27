using EmployeeDepartmentCRUD.Domain.DTOs.Department;
using EmployeeDepartmentCRUD.Domain.Models;

namespace EmployeeDepartmentCRUD.Domain.Contracts.Repositories
{
    public interface IDepartmentRepository
    {
        public Task<IEnumerable<Department>> Get();
        public Task<Department?> GetById(int Id);
        public Task<Department> AddDepartment(Department entity);
        public Task<Department?> UpdateDepartment(int Id, UpdateDepartmentDTO entity);
        public Task<Department?> DeleteDepartment(int Id);
    }
}
