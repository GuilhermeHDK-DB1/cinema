using Cinema.Dados.Persistence;
using Cinema.Dados.Repositorio;
using Cinema.Dominio.Common;
using Cinema.Dominio.Consultas.Filmes;
using Cinema.Dominio.Consultas.Generos;
using Cinema.Dominio.Consultas.Salas;
using Cinema.Dominio.Services.Manipuladores;
using Cinema.Dominio.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cinema.Dominio.Consultas.Sessoes;
using Cinema.Dominio.Consultas.Cliente;

namespace Cinema.IoC;

public static class DependencyInjectionExtension
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(configuration["ConnectionString"]));
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

        services.AddScoped(typeof(IGeneroRepositorio), typeof(GeneroRepositorio));
        services.AddScoped(typeof(IFilmeRepositorio), typeof(FilmeRepositorio));
        services.AddScoped(typeof(ISalaRepositorio), typeof(SalaRepositorio));
        services.AddScoped(typeof(ISessaoRepositorio), typeof(SessaoRepositorio));
        services.AddScoped(typeof(IClienteRepositorio), typeof(ClienteRepositorio));

        services.AddScoped(typeof(IGeneroConsulta), typeof(GeneroConsulta));
        services.AddScoped(typeof(IFilmeConsulta), typeof(FilmeConsulta));
        services.AddScoped(typeof(ISalaConsulta), typeof(SalaConsulta));
        services.AddScoped(typeof(ISessaoConsulta), typeof(SessaoConsulta));
        services.AddScoped(typeof(IClienteConsulta), typeof(ClienteConsulta));

        services.AddScoped<ManipuladorDeGenero>();
        services.AddScoped<ManipuladorDeFilme>();
        services.AddScoped<ManipuladorDeSala>();
        services.AddScoped<ManipuladorDeSessao>();
        services.AddScoped<ManipuladorDeCliente>();
    }
}