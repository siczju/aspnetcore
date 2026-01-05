using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
