using EmployeeDepartmentCRUD.Domain.Models;

namespace EmployeeDepartmentCRUD.Domain.Contracts.Repositories
{
    public interface IDepartmentRepository
    {
        public Task<IEnumerable<Department>> Get();
        public Task<Department?> GetById(int Id);
        public Task<Department> AddDepartment(Department entity);
    }
}
