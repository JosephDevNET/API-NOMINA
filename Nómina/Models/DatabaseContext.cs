using Microsoft.EntityFrameworkCore;

namespace Nómina.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            
        }

        public DbSet<Empleados> Empleados { get; set; }
    }
}
