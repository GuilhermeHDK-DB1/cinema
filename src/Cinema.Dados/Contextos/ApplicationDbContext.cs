using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Entities.Salas;
using Cinema.Dominio.Entities.Sessao;
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
        public DbSet<Sala> Salas { get; set; }
        public DbSet<FilmeSala> Sessao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GeneroConfiguration());
            modelBuilder.ApplyConfiguration(new FilmeConfiguration());
            modelBuilder.ApplyConfiguration(new SalaConfiguration());
            modelBuilder.ApplyConfiguration(new SessaoConfiguration());
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
