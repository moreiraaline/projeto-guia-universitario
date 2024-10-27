using Microsoft.EntityFrameworkCore;

namespace guiaUnivesitario.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Universidade> Universidades { get; set; }
    }
}
