using AutoMapper;
using EmployeeDepartmentCRUD.Data;
using EmployeeDepartmentCRUD.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentCRUD.Domain.Contracts.Repositories
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;

        }

        public async Task<Employee?> AddEmployee(Employee entity)
        {
            var department = await _context.Departments.Where(a => a.DepartmentId == entity.DepartmentId).FirstOrDefaultAsync();
            if(department == null)
            {
                return null;
            }
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Employee>> Get()
        {
            var employee = _context.Employees.ToListAsync();
            return await employee;
        }

        public async Task<Employee?> GetById(int Id)
        {
            var employee = await _context.Employees.Where(c => c.EmployeeId == Id).FirstOrDefaultAsync();
            return employee;
        }

        public async Task<Employee?> UpdateEmployee(Employee entity)
        {
            var employee = await _context.Employees.Where(c => c.EmployeeId == entity.EmployeeId).FirstOrDefaultAsync();
            if(employee is null)
            {
                return null;
            }
            employee.Birthdate = entity.Birthdate;
            employee.Name = entity.Name;
            employee.Age = entity.Age;
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.Where(c => c.EmployeeId == id).FirstOrDefaultAsync();
            if(employee is null){
                return null;
            }
            _context.Remove(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
    }
}
