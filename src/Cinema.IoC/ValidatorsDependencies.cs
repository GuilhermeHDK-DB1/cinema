using Cinema.Dominio.Dtos.Clientes;
using Cinema.Dominio.Dtos.Filmes;
using Cinema.Dominio.Dtos.Generos;
using Cinema.Dominio.Dtos.Salas;
using Cinema.Dominio.Dtos.Sessoes;
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
        services.AddScoped(typeof(IValidator<ObterFilmesDoDoDiaQuery>), typeof(ObterFilmesDoDoDiaValidator));

        services.AddScoped(typeof(IValidator<CadastrarSalaCommand>), typeof(CadastrarSalaValidator));
        services.AddScoped(typeof(IValidator<AtualizarSalaCommand>), typeof(AtualizarSalaValidator));
        services.AddScoped(typeof(IValidator<ExcluirSalaQuery>), typeof(ExcluirSalaValidator));

        services.AddScoped(typeof(IValidator<ObterSessoesPelaDataQuery>), typeof(ObterSessoesPelaDataValidator));
        services.AddScoped(typeof(IValidator<ObterSessoesPorFilmeEDataQuery>), typeof(ObterSessoesPorFilmeEDataValidator));
        services.AddScoped(typeof(IValidator<ObterSessoesPorHorarioQuery>), typeof(ObterSessoesPorHorarioValidator));
        services.AddScoped(typeof(IValidator<CadastrarSessaoCommand>), typeof(CadastrarSessaoValidator));
        services.AddScoped(typeof(IValidator<AtualizarSessaoCommand>), typeof(AtualizarSessaoValidator));
        services.AddScoped(typeof(IValidator<ExcluirSessaoQuery>), typeof(ExcluirSessaoValidator));

        services.AddScoped(typeof(IValidator<ObterPeloCpfQuery>), typeof(ObterPeloCpfValidator));
        services.AddScoped(typeof(IValidator<ObterPeloEmailQuery>), typeof(ObterPeloEmailValidator));
        services.AddScoped(typeof(IValidator<CadastrarClienteCommand>), typeof(CadastrarClienteValidator));
        services.AddScoped(typeof(IValidator<AtualizarClienteCommand>), typeof(AtualizarClienteValidator));
        services.AddScoped(typeof(IValidator<DesativarClienteQuery>), typeof(DesativarClienteValidator));

    }
}
