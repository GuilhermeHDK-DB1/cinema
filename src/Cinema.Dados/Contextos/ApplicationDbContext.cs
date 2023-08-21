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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>()
                .ToTable("Genero");

            modelBuilder.Entity<Genero>()
                .Property(g => g.Id)
                .HasColumnName("id");

            modelBuilder.Entity<Genero>()
                .Property(g => g.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(50)");
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
