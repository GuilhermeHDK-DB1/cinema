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
            modelBuilder.ApplyConfiguration(new GeneroConfiguration());
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}
