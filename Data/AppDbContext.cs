﻿using EmployeeDepartmentCRUD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDepartmentCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
