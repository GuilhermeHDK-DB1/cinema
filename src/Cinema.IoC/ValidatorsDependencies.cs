using Cinema.Dominio.Dtos.Filmes;
using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Dtos.Salas;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.IoC;

public static class ValidatorsDependencies
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddScoped(typeof(IValidator<CadastrarGeneroCommand>), typeof(CadastrarGeneroValidator));
        services.AddScoped(typeof(IValidator<AtualizarGeneroCommand>), typeof(AtualizarGeneroValidator));
        services.AddScoped(typeof(IValidator<ExcluirGeneroQuery>), typeof(ExcluirGeneroValidator));
        services.AddScoped(typeof(IValidator<CadastrarFilmeCommand>), typeof(CadastrarFilmeValidator));
        services.AddScoped(typeof(IValidator<AtualizarFilmeCommand>), typeof(AtualizarFilmeValidator));
        services.AddScoped(typeof(IValidator<ExcluirFilmeQuery>), typeof(ExcluirFilmeValidator));
        services.AddScoped(typeof(IValidator<CadastrarSalaCommand>), typeof(CadastrarSalaValidator));
        services.AddScoped(typeof(IValidator<AtualizarSalaCommand>), typeof(AtualizarSalaValidator));
        services.AddScoped(typeof(IValidator<ExcluirSalaQuery>), typeof(ExcluirSalaValidator));
        services.AddScoped(typeof(IValidator<ObterFilmesDoDoDiaQuery>), typeof(ObterFilmesDoDoDiaValidator));
    }
}
