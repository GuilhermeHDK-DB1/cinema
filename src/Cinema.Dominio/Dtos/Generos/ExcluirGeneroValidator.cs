using FluentValidation;

namespace Cinema.Dominio.Dtos.Generos
{
    public class ExcluirGeneroValidator : AbstractValidator<ExcluirGeneroQuery>
    {
        public ExcluirGeneroValidator()
        {
            RuleFor(query => query.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
