using Chronicle.Domain.Database.Interfaces;
using Chronicle.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Chronicle.Entity.Database
{
    public class ChronicleDbContext : DbContext
    {
        public DbSet<Comment>? Comment { get; set; }
        public DbSet<Author>? Author { get; set; }
        public DbSet<Book>? Book { get; set; }
        public DbSet<Chapter>? Chapter { get; set; }
        public DbSet<Character>? Character { get; set; }

        public ChronicleDbContext(DbContextOptions<ChronicleDbContext> options) : base(options)
        {
            
        }
    }
}
