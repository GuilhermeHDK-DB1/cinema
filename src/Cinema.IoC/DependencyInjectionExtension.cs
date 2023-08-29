using Cinema.Dados.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.IoC;

public static class DependencyInjectionExtension
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(configuration["ConnectionString"]));
    }
}
