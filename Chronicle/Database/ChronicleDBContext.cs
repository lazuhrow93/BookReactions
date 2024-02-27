using Chronicle.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Chronicle.Entity.Database
{
    public class ChronicleDBContext : DbContext
    {
        public DbSet<Comment> Comment { get; set; }

        public ChronicleDBContext(DbContextOptions<ChronicleDBContext> options) : base(options)
        {
            
        }


    }
}
