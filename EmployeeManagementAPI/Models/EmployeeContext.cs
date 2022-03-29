using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementAPI.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => {
                entity.HasIndex(e => e.UserName).IsUnique();
            });
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
