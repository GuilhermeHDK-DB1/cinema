using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Generos;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Dados.Contextos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GeneroConfiguration());
            modelBuilder.ApplyConfiguration(new FilmeConfiguration());
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
