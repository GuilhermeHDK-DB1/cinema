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
                .NotNull()
                .NotEmpty();  //validar com Enum

            RuleFor(filme => filme.Genero)
                .NotNull()
                .NotEmpty(); 
            // TODO: verificar se é possível validar com nome de gênero existente
        }
    }
}
