using Microsoft.EntityFrameworkCore;
using Cinema.Dominio.Entities.Clientes;
using Cinema.Dominio.Entities.Filmes;
using Cinema.Dominio.Entities.Generos;
using Cinema.Dominio.Entities.Ingressos;
using Cinema.Dominio.Entities.Salas;
using Cinema.Dominio.Entities.Sessoes;
using Cinema.Dados.Mappings;
using Cinema.Dominio.Entities;

namespace Cinema.Dados.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Genero> Generos { get; set; }
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Sala> Salas { get; set; }
    public DbSet<Sessao> Sessao { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Ingresso> Ingressos { get; set; }
    public DbSet<SessaoIngresso> SessoesIngressos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GeneroConfiguration());
        modelBuilder.ApplyConfiguration(new FilmeConfiguration());
        modelBuilder.ApplyConfiguration(new SalaConfiguration());
        modelBuilder.ApplyConfiguration(new SessaoConfiguration());
        modelBuilder.ApplyConfiguration(new ClienteConfiguration());
        modelBuilder.ApplyConfiguration(new IngressoConfiguration());
        modelBuilder.ApplyConfiguration(new SessaoIngressoConfiguration());
    }

    public async Task Commit()
    {
        await SaveChangesAsync();
    }
}
