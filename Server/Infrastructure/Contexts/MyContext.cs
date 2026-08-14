using Server.Domain.Entities.Core;
using Microsoft.EntityFrameworkCore;

namespace Server.Infrastructure.Contexts
{
    public class MyContext : DbContext
    {
        // Constructor must be public
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        // DbSets for your entities

        public DbSet<RequestCounter> RequestCounters { get; set; }
        public DbSet<Employee> Employees1 { get; set; }
    }
}
