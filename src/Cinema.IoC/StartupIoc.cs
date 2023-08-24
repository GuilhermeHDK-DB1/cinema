using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cinema.Dominio.Common;
using Cinema.Dados.Contextos;
using Cinema.Dominio.Services.Handlers;
using Cinema.Dados.Repositorio;
using Cinema.Dominio.Services;

namespace Cinema.IoC
{
    public static class StartupIoc
    {
        //public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddDbContext<ApplicationDbContext>(options =>
        //        options.UseSqlServer(configuration["ConnectionString"]));
        //    services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
        //    services.AddScoped(typeof(IGeneroRepositorio), typeof(GeneroRepositorio));
        //    services.AddScoped(typeof(IFilmeRepositorio), typeof(FilmeRepositorio));
        //    services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        //    services.AddScoped<ManipuladorDeGenero>();
        //}
    }
}
