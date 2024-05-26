using EmployeeList.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeList.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }
        public DbSet<Employees> Employees { get; set; }

    }
}
