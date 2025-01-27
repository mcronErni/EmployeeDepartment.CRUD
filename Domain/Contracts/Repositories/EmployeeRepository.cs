using AutoMapper;
using EmployeeDepartmentCRUD.Data;
using EmployeeDepartmentCRUD.Domain.DTOs.EmployeeDTOs;
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
        private readonly IMapper _mapper;

        public EmployeeRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

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
            var employee = await _context.Employees.ToListAsync();
            return employee;
        }

        public async Task<Employee?> GetById(int Id)
        {
            var employee = await _context.Employees.Where(c => c.EmployeeId == Id).FirstOrDefaultAsync();
            return employee;
        }

        public async Task<Employee?> UpdateEmployee(int Id, CRUEmployeeDTO entity)
        {
            var employee = await _context.Employees.Where(c => c.EmployeeId == Id).FirstOrDefaultAsync();
            if(employee is null)
            {
                return null;
            }
            _mapper.Map(entity, employee);
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
