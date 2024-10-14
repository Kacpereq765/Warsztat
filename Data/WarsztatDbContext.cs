using Microsoft.EntityFrameworkCore;
using warsztat.Models;

namespace warsztat.Data
{
    public class warsztatDbContext : DbContext
    {
        public warsztatDbContext(DbContextOptions<warsztatDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}
