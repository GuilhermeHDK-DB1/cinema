using FluentValidation;

namespace Cinema.Dominio.Dtos.Filmes
{
    public class ExcluirFilmeValidator : AbstractValidator<ExcluirFilmeQuery>
    {
        public ExcluirFilmeValidator()
        {
            RuleFor(query => query.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
