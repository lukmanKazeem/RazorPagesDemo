using Microsoft.EntityFrameworkCore;
using RazorPagesDemo.Models.Domain;

namespace RazorPagesDemo.Data
{
    public class RazorPagesDemoDbContext : DbContext
    {
        public RazorPagesDemoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
