using Cinema.Dominio.Common;
using Cinema.Dominio.Extensions;
using FluentValidation;

namespace Cinema.Dominio.Dtos.Filmes
{
    public class CadastrarFilmeValidator : AbstractValidator<CadastrarFilmeCommand>
    {
        public CadastrarFilmeValidator()
        {
            RuleFor(filme => filme.Nome)
                .NotNull()
                .NotEmpty();

            RuleFor(filme => filme.DataDeLancamento)
                .NotNull()
                .NotEmpty()
                .Matches("^(?!0000)\\d{4}$");
            
            RuleFor(filme => filme.Duracao)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(filme => filme.Classificacao)
                .Must(filme => ValidatorExtension.ValidarClassificacaoIndicativa(filme))
                .WithMessage(Resources.ClassificaoIndicativaInvalida);

            RuleFor(filme => filme.Genero)
                .NotNull()
                .NotEmpty(); 
        }
    }
}
