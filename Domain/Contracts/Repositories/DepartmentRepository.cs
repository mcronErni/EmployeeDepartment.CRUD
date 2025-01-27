using AutoMapper;
using EmployeeDepartmentCRUD.Data;
using EmployeeDepartmentCRUD.Domain.DTOs.Department;
using EmployeeDepartmentCRUD.Domain.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentCRUD.Domain.Contracts.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task<Department?> UpdateDepartment(int Id,UpdateDepartmentDTO entity)
        {
            var department = await _context.Departments.Where(c => c.DepartmentId == Id).FirstOrDefaultAsync();
            if (department is null)
            {
                return null;
            }
            _mapper.Map(entity, department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department?> DeleteDepartment(int Id)
        {
            var department = await _context.Departments.Where(c => c.DepartmentId == Id).FirstOrDefaultAsync();
            if(department is null)
            {
                return null;
            }
            _context.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }
    }
}
