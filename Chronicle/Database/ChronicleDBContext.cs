using Chronicle.Domain.Database.Interfaces;
using Chronicle.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Chronicle.Entity.Database
{
    public class ChronicleDbContext : DbContext, IDbContext
    {
        public DbSet<Comment>? Comment { get; set; }

        public ChronicleDbContext(DbContextOptions<ChronicleDbContext> options) : base(options)
        {
            
        }
    }
}
