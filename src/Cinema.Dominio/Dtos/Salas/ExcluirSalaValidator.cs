using FluentValidation;

namespace Cinema.Dominio.Dtos.Salas
{
    public class ExcluirSalaValidator : AbstractValidator<ExcluirSalaQuery>
    {
        public ExcluirSalaValidator()
        {
            RuleFor(query => query.Id)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
