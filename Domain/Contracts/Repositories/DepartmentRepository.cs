using AutoMapper;
using EmployeeDepartmentCRUD.Data;
using EmployeeDepartmentCRUD.Domain.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentCRUD.Domain.Contracts.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Department> AddDepartment(Department entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Department>> Get()
        {
            var department = _context.Departments.Include(d => d.Employees).ToListAsync();
            return await department;
        }

        public async Task<Department?> GetById(int Id)
        {
            var department = await _context.Departments.Where(c => c.DepartmentId == Id).Include(d => d.Employees).FirstOrDefaultAsync();
            return department;
        }
    }
}
