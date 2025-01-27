using EmployeeDepartmentCRUD.Domain.DTOs.EmployeeDTOs;
using EmployeeDepartmentCRUD.Domain.Models;

namespace EmployeeDepartmentCRUD.Domain.Contracts.Repositories
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> Get();
        public Task<Employee?> GetById(int Id);
        public Task<Employee?> AddEmployee(Employee entity);

        public Task<Employee?> UpdateEmployee(int Id, CRUEmployeeDTO entity);
        public Task<Employee?> DeleteEmployee(int id);
    }
}
