using Microsoft.EntityFrameworkCore;

namespace guiaUnivesitario.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet para a tabela de Universidades
        public DbSet<Universidade> Universidades { get; set; }

        // DbSet para a tabela de Usuários
        public DbSet<Usuario> Usuarios { get; set; } // Adicionado
    }
}
