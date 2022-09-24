using Microsoft.EntityFrameworkCore;
using OOP.Models.Lab2;

namespace OOP.Models
{
    public class OOPDbContext : DbContext
    {
        public OOPDbContext(DbContextOptions<OOPDbContext> context) : base(context) { }

        public DbSet<Employee> Employees => Set<Employee>();
    }
}
